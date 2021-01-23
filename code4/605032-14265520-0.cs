    class Person {
      public int ID {get; set; }
      public List<Person> Kids {get; set; }
    }
    List<Person> = snafuPersons
         .GroupBy(person => person.ID)
         .Select(group => new Person {
            ID = group.Key,
            Kids = group.GroupBy(kid => kid.KidID)
                    .Select(kidGroup => new Person{
                       ID = kidGroup.Key,
                       Kids = kidGroup.Select(grandKid => 
                                         new Person { ID = grandKid.GrandKidID})
                                      .ToList()
                    }).ToList()
          }).ToList;
