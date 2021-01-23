    [TestMethod()]
    public void TestCasesA()
    {
        // Arrange/Act
        var target = new TestClass("A");
        // Assert
        Assert.IsInstanceOfType(target.service, typeof(A));
    }
