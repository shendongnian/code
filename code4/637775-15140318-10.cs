    class Person
    {
        public static Person CreateBoy(string name)
        {
            return new Person { Name = name, Gender = Gender.Male };
        }
        public static Person CreateGirl(string name)
        {
            return new Person { Name = name, Gender = Gender.Female };
        }
        public Gender Gender { get; private set; }
        public string Name { get; private set; }
        public override string ToString()
        {
            return Name;
        }
    }
