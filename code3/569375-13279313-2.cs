    var personLookup = new Dictionary<string, Person>();
    var movie = dataContractMovies.Select(m => new Movie {
        Title = m.Title,
        Characters = m.Characters.Select(c => new Character() { Name = c.Name, Person = LookupPerson(c.Person, personLookup) }).ToList()
    });
    
    public Person LookupPerson(string personName, Dictionary<string, Person> personLookup)
    {
            if (!personLookup.ContainsKey(personName))
            {
                personLookup.Add(personName, new Person() { Name = personName });
            }
            return personLookup[personName];
    }
