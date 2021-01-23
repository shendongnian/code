    public struct MTObject
    {
        public string Object { get; set; }
    }
    public struct Person
    {
        public decimal Id { get; set; }
    
        //public string Name { get; set; }
    
        public MTObject Name { get; set; }
    
        public Int32 Age { get; set; }
    }
