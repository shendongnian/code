    var foos = FooRepository.All()
                            .Select(x => new { Id = x.Id,
                                               CustomerId = x.Customer.Id,
                                               CustomerName = x.Name })
                            .AsEnumerable()
                            .Select(s => new FooBrief {
                                       Id = s.Id,
                                       Customer = new SimpleData { 
                                           Id = s.CustomerId,
                                           Name = s.CustomerName
                                       }
                                    });
