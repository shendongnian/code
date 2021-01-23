    public void Delete<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IDto
    {
        var compiled = predicate.Compile();
        var toDelete = m_dtos.FirstOrDefault(dto => (dto is IEntity) && compiled((IEntity)dto));
        m_dtos.Remove(delete);
    }
