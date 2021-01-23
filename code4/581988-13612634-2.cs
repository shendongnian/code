    class MyClass
    {
        public string Desc { get; set; }
        public int ID { get; set; }
        public string Color
        {
            get
            {
                return Desc.Split(new [] { ' ' }).FirstOrDefault();    
            }
        }
    }
