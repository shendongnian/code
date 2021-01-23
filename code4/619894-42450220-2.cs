    // Call it like so.
    MyClass object = new MyClass();
    WalkDictionary(dict, object);
    // At this point the object will be filled out for you.
    public class MyClass
    {
        public List<cColumns> columns { get; set; }
        public cSearch search { get; set; }
    }
    public class cColumns
    {
        public int? data { get; set; }
        public string name { get; set; }
        public bool? searchable { get; set; }
        public bool? orderable { get; set; }
        public cSearch search { get; set; }
    }
    public class cSearch
    {
        public string value { get; set; }
        public bool? regex { get; set; }
    }
