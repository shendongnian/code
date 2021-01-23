    class Person
    {
        public Gender Gender { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
    enum Gender
    {
         Male,
         Female
    }
