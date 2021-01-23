    [TestMethod]
    public void FooTest()
    {
      try
      {
         // setup some database objects
         Foo foo = new Foo();
         Bar bar = new Bar(foo);
         Assert.Fail();
      }
      finally
      {
         // remove database objects.
      }
    }
