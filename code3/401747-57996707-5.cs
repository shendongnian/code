    class Data
    {
        public  string Item1 { get; set; }
        public string Item2 { get; set; }
        public Data()
        {
            this.Item1 = "Item1";
            this.Item2 = "Item2";
        }
    }
    class MyClassEager
    {
        public int Id { get; set; }
        public Lazy<Data> data { get; set; }
    
        public MyClassEager()
        {
            Id = 1;
            data = new Lazy<Data>();
        }
    
    }
