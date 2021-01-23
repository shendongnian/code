    [TestMethod]
    [DeploymentItem("ProjectName\\SumTestData.xml")]
    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                       "|DataDirectory|\\SumTestData.xml",
                       "Row",
                        DataAccessMethod.Sequential)]
    public void SumTest()
    {
        int a1 = Int32.Parse((string)TestContext.DataRow["A1"]);
        int a2 = Int32.Parse((string)TestContext.DataRow["A2"]);
        int result = Int32.Parse((string)TestContext.DataRow["Result"]);
        ExecSumTest(a1, a2, result);
    }
    private static void ExecSumTest(int a1, int a2, int result)
    {
        Assert.AreEqual(a1 + a2, result);
    }
