    public class MyList : List<string>{}
    [Test]        
    public void ListSubclassShouldRoundTrip()
    {
        var list = new MyList { "abc" };
        var clone = Serializer.DeepClone(list);
        Assert.AreEqual(1, clone.Count);
        Assert.AreEqual("abc", clone[0]);
    }
