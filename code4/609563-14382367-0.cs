    [Test]
    public void CovarianceTest()
    {
        var concrete = new Concrete();
        IEnumerable<IInter> t = new List<Concrete> { concrete };
        Assert.IsTrue(new[] { concrete }.SequenceEqual(t));
        List<IInter> t2 = new List<Concrete> { concrete }.ConvertAll(x => (IInter)x);
        Assert.IsTrue(new[] { concrete }.SequenceEqual(t2));
    }
