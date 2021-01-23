    [TestMethod]
    public void TestRevisedDefault() {
         var client = new MyRevisedClass();
         Assert.AreEqual("foo", client.MyFunc());
    }
    [TestMethod]
    public void TestRevisedWithMockedDependency() {
        var dep = new Mock<IDependencyProxy>();
        dep.Setup(mk => mk.Foo()).Returns("bar");
        var client = new MyRevisedClass(dep.Object);
        Assert.AreEqual("bar", client.MyFunc());
    }
