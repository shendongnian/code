    public override int SaveChanges()
    {
        PropertyEntities.Local
            .Where(p => !p.UserId.HasValue && !p.CompanyId.HasValue)
            .ToList()
            .ForEach(p => PropertyEntities.Remove(p));
 
        return base.SaveChanges();
    }
