    [Test]
    public void Test()
    {
         string expected = ApplicationSetting.GlobalVariable + "qux";
         Assert.AreEqual(expected, Baz());
    }
