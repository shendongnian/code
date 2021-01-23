        [TestMethod,DeploymentItem("DataOrigin\\list.csv"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\list.csv", "list#csv", DataAccessMethod.Sequential)]
        public void TestScenario_1_DATADRIVEN()
        {
            // PREPARATION
            string ID = TestContext.DataRow["ID"].ToString();
            string querystring = CreateQueryWithErrorDebug(ID);
            // EXECUTION
            string result = RunXCCQuery(querystring);
            // ASSERTS
            Assert.IsTrue(result.Length > 0);
            Assert.IsTrue(result.Contains(ID));
        }
