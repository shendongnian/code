    private IEnumerable<Person> GetPersons(Gender gender)
    {
        string fileName = // get file name depending on gender
        return File.ReadAllLines(fileName)
                   .Select(line => new Person { Name = line, Gender = gender })
                   .ToList();
    }
