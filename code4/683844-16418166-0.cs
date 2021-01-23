    public class ConsoleApp
        {
            private static void Main(string[] args)
            {
                List<Person> p = new List<Person>();
                p.Add(new Person() {Age = 25, Name = "Jo"});
                p.Add(new Person() {Age = 10, Name = "Jo"});
                p.Add(new Person() {Age = 2, Name = "Jo"});
                p.Sort();
                
            }
        }
    
        public class Person : IComparable<Person>
        {
            public string Name { get; set; }
            public int Age { get; set; }
    
            public int CompareTo(Person other)
            {
                return other == null ? 1 : Age.CompareTo(other.Age);
            }
        }
