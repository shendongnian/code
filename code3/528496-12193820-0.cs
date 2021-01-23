    class Person : PersonCreator
    {
        public Person(int initialAge, string initialName)
        {
            Age = initialAge;
            Name = initialName;
        }
        public int Age
        {
            set;
            get;
        }
        public string Name
        {
            set;
            get;
        }
    } 
