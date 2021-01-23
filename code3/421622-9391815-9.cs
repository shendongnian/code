    public class ViewModel
    {
        public List<Person> Items
        {
            get
            {
                return new List<Person>
                {
                    new Person { Name = "P1", Age = 1 },
                    new Person { Name = "P2", Age = 2 }
                };
            }
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
