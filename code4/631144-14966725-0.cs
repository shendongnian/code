    private class MyClass
    {
        public MyClass(int width, int height)
            : base()
        { Width = width; Height = height; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
    [TestMethod]
    public void TestMethod1()
    {
        var test1 = new MyClass(0, 0);
        var test2 = new MyClass(1, 1);
        Assert.AreEqual(test1, test2, "Show me A [{0}] and B [{1}]", test1, test2);
    }
