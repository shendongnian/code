    var groupedPersons = persons.GroupBy(person => person.IsTest ? 
                          new {
                                  person.Name, 
                                  person.Age, 
                                  person.Address,
                                  Height = 0
                               } 
                         : new {
                                  person.Name, 
                                  person.Age, 
                                  person.Address, 
                                  person.Height}).ToList();
