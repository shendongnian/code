    class Company
    {
        public Company(string name)
        {
            Name = name;
        }
    
        public string Name { get; private set; }
    
        public override string ToString()
        {
            return Name;
        }
    }
