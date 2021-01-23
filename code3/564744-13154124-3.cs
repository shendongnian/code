    [Test]
    public void TestNameTest()
    {
        var names = new List<string>() {"Johan", "Tkrause"};
        var readOnlyCollection = new ReadOnlyCollection<string>(names);
        names.Add("Lars");
        Assert.AreEqual(3,readOnlyCollection.Count);
    }
    
