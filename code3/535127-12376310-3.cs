    [Test]
    public void keywordsTest()
    {
        foreach(var pair in oldSites.Zip(newSites, (o, n) => new {Old = o, New = n}))
        {
             Assert.IsTrue(this.scc.metaKeywordsChecker(pair.Old, pair.New));
        }
    }
