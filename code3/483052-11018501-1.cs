    [Test]
    [Category("Hello")]
    public void TestCategory()
    {
      Assert.IsTrue(((ArrayList)TestContext.CurrentContext.Test.Properties["_CATEGORIES"]).Contains("Hello"));
    }
