    [Serializable]
    public sealed class MyData
    {
        public string Data { get; set; }
        public string Data1 { get; set; }
    }
...
    [WebMethod(EnableSession = true)]
    public MyData testing(string testId)
    {
        string data = string.Empty;
        string data1 = string.Empty;
        List<test1> datalist1 = new List<test1>();
        List<test> datalist = new List<test>();
    
        //coding
        data = jsonSerialize.Serialize(datalist1);
        data1 = jsonSerialize.Serialize(datalist);
        return new MyData { Data = data, Data1 = data1 };
    }
