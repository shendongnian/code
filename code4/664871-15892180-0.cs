    class MyObject
    {
        public string title { get; set; }
        public List<MyObject> children { get; set; }
    }
    var deserialized = JsonConvert.DeserializeObject<List<MyObject>>(s);
