    query = query.Select(t => new Ticket { 
        Owner = new Owner {Name = t.Owner.Name}, 
        Dependency = new Dependency  {Name = t.Dependency.Name}
    }); 
    return query.ToList();
