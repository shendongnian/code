    [TestMethod]
    public void Test_Text_Null()
    {
        Assert.AreEqual(null, new Foo(null).Text);
    }
    [TestMethod]
    public void Test_Text_Empty()
    {
        Assert.AreEqual("", new Foo("").Text);
    }
    [TestMethod]
    public void Test_Text_Something()
    {
        Assert.AreEqual("abc", new Foo("abc").Text);
    }
