    IList<Person> allPersons = new List<Person>();
    using (var reader = new CsvHelper.CsvReader(yourTextReader))
    {
        while (reader.Read())
        {
            var person = new Person();
            person.FirstName = reader.CurrentRecord.ElementAt(0);
            person.LastName = reader.CurrentRecord.ElementAtOrDefault(1);
            person.Attributes = reader.CurrentRecord.Skip(2).ToList();
            allPersons.Add(person);
        }
    }
