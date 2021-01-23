    var groupedPersons = persons.GroupBy(person => 
                          new {
                                  person.Name, 
                                  person.Age, 
                                  person.Address,
                                  Height = person.IsTest ? 0 : person.Height,
                                  person.IsTest
                               }).ToList();
