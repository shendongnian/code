    List<PersonData> AllPersons = new List<PersonData>()
    {
        new PersonData { Id = 1, FirstName = "Tom" },
        new PersonData { Id = 2, FirstName = "Jon" },
        new PersonData { Id = 3, FirstName = "Tom" }
    };
    string uniqueColumn = "FirstName";
    var prop = typeof(PersonData).GetProperty(uniqueColumn);
    var duplicateKeys = AllPersons.GroupBy(p => prop.GetValue(prop, null))
                                  .Select(g => new { g.Key, Count = g.Count() })
                                  .Where(x => x.Count > 1)
                                  .Select(d => d.Key)
                                  .ToList();
    var duplicates = AllPersons.Where(p => duplicateKeys.Contains(prop.GetValue(prop, null))).ToList();
