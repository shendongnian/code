    [ProtoContract]
    public class ListWrapper
    {
        [ProtoMember(1)]
        public List<string> BasicList { get; set; }
        [ProtoMember(2)]
        public MyList MyList { get; set; }
        [ProtoMember(3)]
        public MyContractList MyContractList { get; set; }
    }
    [Test]
    public void TestBasicListAsMember()
    {
        var obj = new ListWrapper { BasicList = new List<string> { "abc" } };
        var clone = Serializer.DeepClone(obj);
        Assert.IsNull(clone.MyList);
        Assert.IsNull(clone.MyContractList);
        Assert.AreEqual(1, clone.BasicList.Count);
        Assert.AreEqual("abc", clone.BasicList[0]);
    }
    [Test]
    public void TestMyListAsMember()
    {
        var obj = new ListWrapper { MyList = new MyList { "abc" } };
        var clone = Serializer.DeepClone(obj);
        Assert.IsNull(clone.BasicList);
        Assert.IsNull(clone.MyContractList);
        Assert.AreEqual(1, clone.MyList.Count);
        Assert.AreEqual("abc", clone.MyList[0]);
    }
    [Test]
    public void TestMyContractListAsMember()
    {
        var obj = new ListWrapper { MyContractList = new MyContractList { "abc" } };
        var clone = Serializer.DeepClone(obj);
        Assert.IsNull(clone.BasicList);
        Assert.IsNull(clone.MyList);
        Assert.AreEqual(1, clone.MyContractList.Count);
        Assert.AreEqual("abc", clone.MyContractList[0]);
    }
