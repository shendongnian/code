    [TestMethod]
    public void MyDoSomethingTest()
    {
       string errorMessage = string.Empty;
       var actual = myClass.DoSomething(..., ref errorMessage)
       Assert.AreEqual("MyErrorMessage", errorMessage);
       Assert.AreEqual(0, FormattedData.Count);
    }
