    [Serializable]
    public sealed class MyData
    {
        public List<test> Data { get; set; }
        public List<test1> Data1 { get; set; }
    }
...
    [WebMethod(EnableSession = true)]
    public string testing(string testId)
    {
        MyData data = new MyData();
        string alldata = string.Empty;
        List<test1> datalist1 = new List<test1>();
        List<test> datalist = new List<test>();
    
        //coding
        data.Data = datalist1;
        data.Data1 = datalist;
        alldata = jsonSerialize.Serialize(data);
        return alldata;
    }
