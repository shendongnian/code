    class Animal
    {
        public string Name { get; set; }
        public Animal(string name)
        {
            Name = name;
        }
        
    }
    class Cat : Animal
    {
        // Put cat-only properties here...
        public Cat(string name) : base(name)
        {
            // Set cat-specific properties here...
        }
    }
