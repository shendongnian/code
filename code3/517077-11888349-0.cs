    var customers = uow
               .GetAllCustomers()
               .AsEnumerable()
               .Select(c => new CustomerBE { FirstName = c.Firstname,
                                             Id = c.Id
                                              // ...
                                           }
                      )
               .ToList();
