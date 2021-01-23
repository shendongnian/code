    using (var reader = new CsvHelper.CsvReader(yourTextReader))
    {
        while (reader.Read())
        {
            IEnumerable<CsvHelper.CsvReader> allRecords = reader.AsSequence();
            IEnumerable<Person> allPersons = allRecords
            .Select(rec =>
            {
                var person = new Person();
                person.FirstName = rec.GetField<string>(0);
                person.LastName = rec.GetField<string>(1);
                person.Attributes = rec.FieldHeaders.Skip(2).Select(c => rec.GetField<string>(c)).ToList();
                return person;
            }).ToList();
        }
    }
