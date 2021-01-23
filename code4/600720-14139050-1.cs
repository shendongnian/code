    [TestMethod]
    [DeploymentItem("ProjectName\\FooTestData.xml")]
    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                       "|DataDirectory|\\FooTestData.xml", "Row",
                        DataAccessMethod.Sequential)]
    public void FooTest()
    {
        int x = Int32.Parse((string)TestContext.DataRow["Data"]);
        // some assert
    }
