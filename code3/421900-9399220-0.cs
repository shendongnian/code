    [Test]
    [TestCase(5)]
    [TestCase(0)]
    [TestCase(int.MaxValue)]
    [TestCase(int.MinValue)]
    public void InvalidIndices(int index)
    {
        Assert.DoesNotThrow(() => yourObj.InputDataStore(index, "don't care"));
    }
