    [ProtoContract]
    public class MyContractList : List<string> { }
    [Test]
    public void ContractListSubclassShouldRoundTrip()
    {
        var list = new MyContractList { "abc" };
        var clone = Serializer.DeepClone(list);
        Assert.AreEqual(1, clone.Count);
        Assert.AreEqual("abc", clone[0]);
    }
