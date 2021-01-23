    [TestMethod]
    public void TestSomeMethod()
    {
        // Arrange/Act
        var target = new TestClass((new Mock<IService>()).Object);
        target.Method("B");
        // Assert
        Assert.IsInstanceOfType(target.Service, typeof(B));
    }
