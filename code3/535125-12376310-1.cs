    [Test]
    public void YourTest([Range(0,1700)] int index)
    {
        var prev = ... oldSites[index];
        var curr = ... newSites[index];
    
        Assert.AreEqual(prev, curr, "failed with index=" + index);
    }
