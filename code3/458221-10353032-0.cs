    [TestMethod]
    public void TextReturnsTextPassedToConstructor()
    {
        string text = "A string";
        Foo foo = new Foo(text);
    
        Assert.AreEqual(text, foo.Text);
    }
