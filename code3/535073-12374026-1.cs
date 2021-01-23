    var Data = base.Entities.Member.First(c => c.Id == entity.Id);
    if (Data != null)
    {
        Data = entity;
        base.Entities.SaveChanges();
    }
