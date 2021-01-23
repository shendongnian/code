    [TestMethod]
    public void FooTest()
    {
        Mock<IFoo> fooMock = new Mock<IFoo>();
        fooMock.Object.Bar1();
   
        fooMock.VerifyAny(
            f => f.Bar1(),
            f => f.Bar2());
    }
