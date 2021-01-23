    [TestMethod]
    public void given_null_string_expect_null()
    {
        string initalizeText = null;
        Foo realFoo = new Foo(initalizeText);
        Assert.AreEqual(initalizeText, realFoo.Text);
    }
    [TestMethod]
    public void given_special_character_string_expect_that_character()
    {
        string initalizeText = "!";
        Foo realFoo = new Foo(initalizeText);
        Assert.AreEqual(initalizeText, realFoo.Text);
    }
