    class Parent
    {
        public ICollection<Child> Childs { get; set; }  <- one-to-many collection
        public ICollection<string> Names { get; set; }  <- element collection
    }
    class Child
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
