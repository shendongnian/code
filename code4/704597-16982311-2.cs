    var customers = results
        .Where(x => String.IsNullOrWhiteSpace(x.Phn1))
        .Select(x => new Customer() { Name = x.Name, Phone = x.Phn1 })
        .Union(
            results
            .Where(x => String.IsNullOrWhiteSpace(x.Phn2))
            .Select(x => new Customer() { Name = x.Name, Phone = x.Phn2 })
        );
