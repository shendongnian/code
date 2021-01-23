    [TestMethod]
    public void FooTest()
    {
      using (FooBarDatabaseContext context = new FooBarDatabaseContext())
      {
        // setup some db objects.
        Foo foo = context.NewFoo();
        Bar bar = context.NewBar(foo);
        Assert.Fail();
      } // calls dispose. deletes bar, then foo.
    }
