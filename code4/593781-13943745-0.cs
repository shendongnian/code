    private FooType foo;
    [TestInitialize()]
    public void TestInitialize()
    {
        foo = CreateFooObject();
    }
    [TestMethod()]
    public void TestToAssertThatAbcStuffGetsDone()
    {
        foo.DoAbcStuff();
        Assert.IsTrue(foo.DidAbc());
    }
    [TestMethod()]
    public void TestToAssertThatXyzStuffGetsDone()
    {
        foo.DoXyzStuff();
        Assert.IsTrue(foo.DidXyz());
    }
