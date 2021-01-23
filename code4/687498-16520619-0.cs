    var customers = repository.GetAll<Customer>();
    var ethnicities = repository.GetAll<Ethnicity>().ToDictionary(e => e.Id);
    var query1 = customers
      .GroupBy(c => c.EthnicityId)
      .Select(g => new { Key = ethnicities[g.Key], Count = g.Count() };
