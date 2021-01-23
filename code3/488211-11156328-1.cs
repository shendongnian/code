    var table = entities.Select(x => new {
                                           x.Id,
                                           Contact = x.Contact.Name,
                                           Address = x.Address.Address
                                          }).CopyToDataTable();
