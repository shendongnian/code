    List<Person> persons1 = new List<Person>
               {
                        new Person {Id = 1, Name = "Person 1"},
                        new Person {Id = 2, Name = "Person 2"},
                        new Person {Id = 3, Name = "Person 3"},
                        new Person {Id = 4, Name = "Person 4"}
               };
            List<Person> persons2 = new List<Person>
               {
                        new Person {Id = 1, Name = "Person 1"},
                        new Person {Id = 2, Name = "Person 2"},
                        new Person {Id = 3, Name = "Person 3"},
                        new Person {Id = 4, Name = "Person 4"},
                        new Person {Id = 5, Name = "Person 5"},
                        new Person {Id = 6, Name = "Person 6"},
                        new Person {Id = 7, Name = "Person 7"}
               };
            var output = (from ps1 in persons1
                          from ps2 in persons2
                          where ps1.Id == ps2.Id
                          select ps2.Name).ToList();
