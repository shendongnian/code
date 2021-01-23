    [Test]
    public void MyTest()
    {
        Stack<int> stack = new Stack<int>(new[] { 1, 2, 3, 4, 5 });
        int pop = stack.Pop();
        Assert.AreEqual(stack.Count, 4);
        Assert.AreEqual(pop, 5);
    }
