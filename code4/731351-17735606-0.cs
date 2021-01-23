    string json = @"{""dest"":[ { ""mode"": ""1"", ""test"":""test1,test,test2""},{ ""mode"": ""2"", ""test"": ""test3"" }]}";
    var obj = new JavaScriptSerializer().Deserialize<MyObject>(json);
    public class Dest
    {
        public string mode { get; set; }
        public string test { get; set; }
    }
    public class MyObject
    {
        public List<Dest> dest { get; set; }
    }
