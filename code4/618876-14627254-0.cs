    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Person(int age, string name)
        {
            Age = age;
            Name = name;
        }
        public int DateOfBirth()
        {
            return 2013 - Age;
        }
    }
            class Program
            {
                public static void Main()
                {
                    Person Mother = new Person(35, "Alice");
                    Person Son = new Person(12, "Johny");
                    Mother.Name = "Lucy";  // Just changing the value afterwards
                    if (Mother.Age > Son.Age)
                    {
                        int year = Mother.DateOfBirth();
                        Console.WriteLine("Mom was born in {0}.", year);
                    }
                }
            }
