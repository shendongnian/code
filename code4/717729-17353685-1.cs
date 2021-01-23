    IEnumerable<IEnumerable<string>> allRecords = .....;
    IEnumerable<Person> allPersons = allRecords
    .Select(rec => 
    {
        var person = new Person();
        person.FirstName = rec.ElementAt(0);
        person.LastName = rec.ElementAtOrDefault(1);
        person.Attributes = rec.Skip(2).ToList();
        return person;
    }).ToList();
