    [Test] 
    public void EqualityOnInts()
    {
        object a = 1;
        object b = 1;
        Assert.AreEqual(a, b);
        Assert.IsTrue(1.Equals(a));
        Assert.IsTrue(b.Equals(1));
    }
