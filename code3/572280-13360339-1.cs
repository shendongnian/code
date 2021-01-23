    public class Person
    {
        public string Name { get; set; }
    }
    public class Program
    {
        private static void Main(string[] args)
        {
            IEnumerable<Person> persons = GetPersons();
            // invoke the method, passing a filter expression to be used
            PrintFiltered(persons, p => p.Name.StartsWith("F"));
        }
        private static void PrintFiltered(IEnumerable<Person> persons, Func<Person, bool> filter)
        {
            // use the expression to filter the sequence
            foreach (Person person in persons.Where(filter))
            {
                Console.WriteLine(person.Name);
            }
        }
        private static IEnumerable<Person> GetPersons()
        {
            return new[]
                {
                    new Person { Name = "Fredrik" },
                    new Person { Name = "John" },
                    new Person { Name = "Steven" },
                };
        }
    }
