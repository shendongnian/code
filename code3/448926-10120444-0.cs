    using (MyDatabaseEntities context = new MyDatabaseEntities())
    {
       return context.Persons
        .Where(p => ages.Contains(p.Age))
        .Select(p => new {p, p.Car, p.Company, p.Address)
        .ToList();
    }
