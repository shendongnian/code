    class source
    {
        public List<category> Categories = new List<category>();
    }
    class category
    {
        public category(string name)
        {
            Name = name;
        }
        public string Name {get;set;}
        public List<product> Products = new List<product>();
    }
    class product
    {
        public product(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
