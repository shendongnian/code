    class Program
    {
        class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        static List<Person> GetPerson() => new List<Person>()
        {
            new Person() { Id = 0, Name = "Artur", Age = 26 },
            new Person() { Id = 1, Name = "Edward", Age = 30 },
            new Person() { Id = 2, Name = "Krzysiek", Age = 67 },
            new Person() { Id = 3, Name = "Piotr", Age = 23 },
            new Person() { Id = 4, Name = "Adam", Age = 11 },
        };
        static void Main(string[] args)
        {
            List<Person> persons = GetPerson();
            int ageTotal = 0;
            Parallel.ForEach
            (
                persons,
                () => 0,
                (person, loopState, subtotal) => subtotal + person.Age,
                (subtotal) => Interlocked.Add(ref ageTotal, subtotal)
            );
            
            Console.WriteLine($"Age total: {ageTotal}");
            Console.ReadKey();
        }
    }
