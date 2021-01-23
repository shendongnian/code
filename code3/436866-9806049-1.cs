        public class Person 
        {
            public Int16 ID { get; private set; }
            public string Name { get; private set; }
            public ReadOnlyCollection<Toy> Toys { get; private set; }
            public Person(Int16 id, string name, List<Toy> toys)
            { ID = id; Name = name; Toys = toys; } 
    
            public static Person CreateWithToys(Int16 id, string name,
                IEnumerable<string> toyNames) // or could use “params string[]”, too
            {
                var person = new Person(id, name, null);
                var toys = new ReadOnlyCollection<Toy>(
                    toyNames.Select(toyName => new Toy(person, toyName)).ToList());
                person.Toys = toys;
            }
        }
        [...]
        var jimmy = Person.CreateWithToys(47, "Jimmy",
            new[] { "Rattle", "Batman costume", "Nuclear missile" });
        // or, if you used “params string[]” above,
        var jimmy = Person.CreateWithToys(47, "Jimmy",
            "Rattle", "Batman costume", "Nuclear missile");
    In more complex cases, you may have to make some of the setters *internal* instead of *private* so that such a static method can access what it needs to access.
