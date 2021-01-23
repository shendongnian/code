     public class Person
        {
            public int Age { get; set; }
            public string Name { get; set; }
        }
    
        public class MyDataSource
        {
            public static List<Person> Persons = new List<Person>
            {
                new Person{Age=30,Name="Ram"},
                new Person{Age=33,Name="Rahim"},
            };
        }
