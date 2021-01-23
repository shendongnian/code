    [Serializable]
    public sealed class MyData
    {
        public string Data { get; set; }
        public string Data1 { get; set; }
    }
...
    return new MyData { Data = data, Data1 = data1 };
