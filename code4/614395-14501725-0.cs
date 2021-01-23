    public class Model
    {
        public string Owner { get; set; }
        public List<MyList> ListCollection { get; set; }
    
        public class MyList
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }
    }
