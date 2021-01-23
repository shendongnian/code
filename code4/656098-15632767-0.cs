    public class MyClass
    {
            ...
            public IEnumerable<MyModel> allDetails { get; set; }
            public int age { set; get; }
            public string gender { set; get; }
            public int schoolid { set; get; }
            ...
    }
    public class MyModel
    {
        ...
        public IEnumerable<MyClass> allDetails { get; set; }
        ...
    
    }
