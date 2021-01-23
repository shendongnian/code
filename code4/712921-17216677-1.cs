    // Outdented to avoid scrolling
    var foos = FooRepository.All()
        .Select(x => new { Id = x.Id,
                           CustomerId = x.Customer.Id,
                           CustomerName = x.Name })
        .AsEnumerable()
        .Select(s => new FooBrief {
                   Id = s.Id,
                   Customer = SimpleData.To(s,
                                            s => s.CustomerId,
                                            s => s.CustomerName)
                });
