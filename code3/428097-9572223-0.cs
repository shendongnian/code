    public void Save(Users entity) 
    { 
        context.Entry(entity).State = entity.Id == 0
            ? EntityState.Added
            : EntityState.Modified;
        context.SaveChanges();
    } 
