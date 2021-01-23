    var personsAndOldest = db.Persons
        .GroupBy(person => person.SomeThingThatCanBeGroupedForPerson)
        .Select(g => new 
            {
                a = g.First(),
                o = g.Aggregate((pers1, pers2) =>
                    pers1.BirthDate > pers2.BirthDate ? pers1 : pers2)
            })
        .Select(pair => new
            {
                FirstName = pair.a.FirstName,
                LastName = pair.a.LastName,
                BirthDate = pair.a.BirthDate,
                FullnameOfOldes = pair.o.FirstName + " " + pair.o.LastName
            });
