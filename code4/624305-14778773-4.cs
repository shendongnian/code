    public class TestHeader
    {
        public string Data {get;set;}
    }
    public class TestCol : CollectionBase
    {
        //...
    }
    public class TestObj
    {
        public TestHeader header {get;set;}
        public TestCol col {get;set;}
    }
