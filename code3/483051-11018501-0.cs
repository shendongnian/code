    [Test]
    [Category("Hello")]
    public void justtest()
    {
      Assert.IsTrue(((ArrayList)TestContext.CurrentContext.Test.Properties["_CATEGORIES"]).Contains("Hello"));
    }
