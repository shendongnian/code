    var yourQuery = context.Persons.Include("Car").Include("Company").Include("Address")
                     .Where(p=>ages.Contains(p.Age));
    var HarmQuery = context.Persons
        .Where(p => ages.Contains(p.Age))
        .Select(p => new {p, p.Car, p.Company, p.Address});
    
    
    return yourQuery.ToList();
