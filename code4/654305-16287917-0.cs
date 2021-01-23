    [TestMethod]
    [DataTestMethod]
    [DataRow("a")]
    [DataRow("b")]
    [DataRow("c")]
    public void TestMethod2(string param)
    {
        Debug.WriteLine("TestMethod2 param=" + param);
    }
