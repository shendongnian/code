    var personIdentityComparer = new PersonIdentityEqualityComparer();
    var personValueComparer = new PersonValueEqualityComparer();
    var joseph = new Person { Id = 1, FirstName = "Joseph" }
    var persons = new List<Person>
    {
       new Person { Id = 1, FirstName = "Joe" },
       new Person { Id = 2, FirstName = "Mary" },
       joseph
    };
    
    var personsIdentity = new HashSet<Person>(persons, personIdentityComparer);
    var personsValue = new HashSet<Person>(persons, personValueComparer);
    
    var containsJoseph = personsIdentity.Contains(joseph);
    Console.WriteLine(containsJoseph); // false;
    
    containsJoseph = personsValue.Contains(joseph);
    Console.WriteLine(containsJoseph); // true;
