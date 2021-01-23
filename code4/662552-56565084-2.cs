    var persons = (from p in db.Persons
                      select new 
                      {
                          Id = p.Id,
                          Name = p.Name,
                          LastName = p.LastName,
                          Email = p.Email
                      }
                  ).AsEnumerable()
                    //construct the complex type outside of DB  (to prevent the exception that model cannot be constructed in linq to entities)
                    .Select(item =>
                        
                        new Person
                        {
                            Id = item.Id,
                            Name = item.Name,
                            LastName = item.LastName,
                            Email = item.Email
                        }).ToList(); 
                return persons;
