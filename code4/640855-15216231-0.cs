    var persons = new List<Person>();
    persons.Add(new Person { Id = "123", FirstName = "AAA", LastName = "XXX" });
    persons.Add(new Person { Id = "123", FirstName = "BBB", LastName = "WWW" });
    persons.Add(new Person { Id = "456", FirstName = "CCC", LastName = "XXX" });
    persons.Add(new Person { Id = "456", FirstName = "DDD", LastName = "YYY" });
    persons.Add(new Person { Id = "789", FirstName = "EEE", LastName = "ZZZ" });
    var duplicateKeys = persons.GroupBy(p => p.Id).Select(g => new { g.Key, Count = g.Count() }).Where(x => x.Count > 1).ToList().Select(d => d.Key);
    var duplicatePersons = persons.Where(p => duplicateKeys.Contains(p.Id)).ToList();
    var unique = persons.GroupBy(p => p.Id).ToList();
