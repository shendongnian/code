    [TestMethod]
    public void TestMethod1()
    {
        string source = "aaa<@bbb@>aaa<@bb@>c";
        Regex r = new Regex("(<@.+?@>)");
        string[] result = r.Split(source);
        Assert.AreEqual(5, result.Length);
    }
