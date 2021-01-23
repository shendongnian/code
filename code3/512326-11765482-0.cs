    public IEnumerable<AnEntity> Select(ISpecification<AnEntity> spec)
    {
        return Session.Query<AnEntity>() 
            .Where(spec.Satisfies)
            .ToList();
    }
