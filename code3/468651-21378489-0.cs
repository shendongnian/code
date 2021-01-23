    [Test]
    public void StringInterningTests()
    {
        string a = "Hello";
        string stringFromCharArray = new string(new char[] {'H', 'e', 'l', 'l', 'o'});
        
        Assert.IsTrue("Hello" == a);
        Assert.IsTrue(stringFromCharArray == "Hello");
        Assert.IsTrue(new String(new char[]{'H','e','l','l','o'}) == stringFromCharArray);
    }
