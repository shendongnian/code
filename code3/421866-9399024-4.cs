    class NamedItem
    {
        public NamedItem(string name)
        {
            Name = name;
        }
    
        public string Name { get; private set; }
    
        public override string ToString()
        {
            return Name;
        }
    }
    class Company : NamedItem
    {
        public Company(string name)
            : base(name)
        {
        }
    }
    class Employee : NamedItem
    {
        public Employee (string name)
            : base(name)
        {
        }
    }
