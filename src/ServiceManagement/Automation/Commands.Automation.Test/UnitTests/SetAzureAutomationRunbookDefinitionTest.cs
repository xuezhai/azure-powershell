﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using Microsoft.Azure.Commands.Automation.Cmdlet;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;

namespace Microsoft.Azure.Commands.Automation.Test.UnitTests
{
    [TestClass]
    public class SetAzureAutomationRunbookDefinitionTest : TestBase
    {
        private Mock<IAutomationClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private SetAzureAutomationRunbookDefinition cmdlet;

        [TestInitialize]
        public void SetupTest()
        {
            this.mockAutomationClient = new Mock<IAutomationClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new SetAzureAutomationRunbookDefinition
                              {
                                  AutomationClient = this.mockAutomationClient.Object,
                                  CommandRuntime = this.mockCommandRuntime
                              };
        }

        [TestMethod]
        public void SetAzureAutomationRunbookDefinitionByIdSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string runbookPath = "runbook.ps1";
            var runbookId = new Guid();

            this.mockAutomationClient.Setup(
                f => f.UpdateRunbookDefinition(accountName, runbookId, runbookPath, false));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Id = runbookId;
            this.cmdlet.Path = runbookPath;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(
                f => f.UpdateRunbookDefinition(accountName, runbookId, runbookPath, false),
                Times.Once());
        }

        [TestMethod]
        public void SetAzureAutomationRunbookDefinitionByNameSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string runbookName = "runbook";
            string runbookPath = "runbook.ps1";

            this.mockAutomationClient.Setup(
                f => f.UpdateRunbookDefinition(accountName, runbookName, runbookPath, false));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = runbookName;
            this.cmdlet.Path = runbookPath;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(
                f => f.UpdateRunbookDefinition(accountName, runbookName, runbookPath, false),
                Times.Once());
        }

        [TestMethod]
        public void SetAzureAutomationRunbookDefinitionByIdWithOverwriteSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string runbookPath = "runbook.ps1";
            var runbookId = new Guid();

            this.mockAutomationClient.Setup(
                f => f.UpdateRunbookDefinition(accountName, runbookId, runbookPath, true));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Id = runbookId;
            this.cmdlet.Path = runbookPath;
            this.cmdlet.Overwrite = true;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(
                f => f.UpdateRunbookDefinition(accountName, runbookId, runbookPath, true),
                Times.Once());
        }

        [TestMethod]
        public void SetAzureAutomationRunbookDefinitionByNameWithOverwriteSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string runbookName = "runbook";
            string runbookPath = "runbook.ps1";

            this.mockAutomationClient.Setup(
                f => f.UpdateRunbookDefinition(accountName, runbookName, runbookPath, true));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = runbookName;
            this.cmdlet.Path = runbookPath;
            this.cmdlet.Overwrite = true;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(
                f => f.UpdateRunbookDefinition(accountName, runbookName, runbookPath, true),
                Times.Once());
        }
    }
}
