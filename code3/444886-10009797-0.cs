    var people = (from p in context.People
                       where p.Name == search.PersonName
                       select new Person{
                              ID = p.ID,
                            Name = p.Name,
                            Pets = (from pt in context.Pets
                                    where pt.OwnerId == p.ID
                                    select new Pet {
                                       id = pt.ID,
                                     OwnerId = pt.OwnerId,
                                     Name = pt.Name
                                    })
                       }).Include("Pet").AsQueryable();
