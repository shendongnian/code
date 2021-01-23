     var persons = (from p in db.Persons
                      select new Person
                      {
                          Id = p.Id,
                          Name = p.Name,
                          LastName = p.LastName,
                          Email = p.Email
                      }
                  ).AsEnumerable();
      return persons;
 
