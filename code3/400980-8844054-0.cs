    King k = new King ( Id = Guid.NewGuid(); }
    context.Kings.Add(king);
    context.SaveChanges();
    
    Throne t = new Throne 
    { 
        Id = Guid.NewGuid(),
        KingId = (k.Id)
    }
    
    context.Thrones.Add(t);
    context.SaveChanges();
