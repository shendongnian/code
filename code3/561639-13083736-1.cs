    public class MyClass
    {
        public int LocationId { get; set; }
        public int id { get; set; }
    }
    [Serializable]
    public class jSonObject
    {
        public int user_id { get; set; }
        public List<MyClass> myObject { get; set; }
    }
