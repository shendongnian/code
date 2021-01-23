    [TestMethod]
    public void FibonacciFirstSixTest()
    {
        var actual = MyClass.Fibonacci();
        int[] expected = { 0, 1, 1, 2, 3, 5 };
    
        Assert.IsTrue(actual.Take(6).SequenceEqual(expected));
    }
