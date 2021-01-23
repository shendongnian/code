    public IQueryable<Kitten> GetKittens()
    {
        return context.Kittens.AsNoTracking().Where(k => !k.IsDeleted);
    }
    
