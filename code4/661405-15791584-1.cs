    [Test]
    public void BigListTest()
    {
        BigList<string> test = new BigList<string>();
        var bigIndex = new BigInteger(int.MaxValue);
        string value = "test";
        bigIndex *= 2;
        test[bigIndex] = value;
        Assert.AreEqual(test[bigIndex],value);
    }
