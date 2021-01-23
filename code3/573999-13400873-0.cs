    var personsAndOldest = db.Persons.GroupBy(person => person.SomeThingThatCanBeGroupedForPerson).Select(a => 
        {
            var first = a.First();
            var oldest = a.Aggregate((pers1, pers2) => pers1.BirthDate > pers2.BirthDate ? pers1 : pers2);
            return new
            {
                FirstName = first.FirstName,
                LastName = first.LastName,
                BirthDate = first.BirthDate,
                FullnameOfOldes = oldest.FirstName + " " + oldest.LastName)
            };
        });
