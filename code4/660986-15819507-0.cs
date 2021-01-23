    var contacts = context.Contacts.Where(row => row.CategoryId == 1)
                          .Select(row => new {
                                                 ContactId = row.Id,
                                                 Name = row.Name,
                                                 CustomerName = row.Customer.Name
                                             }).ToList();
