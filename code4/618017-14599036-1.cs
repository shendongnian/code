    public List<TEntity> buscar<TEntity>(string valor, string atributo) where TEntity : class
    {
        return db.Set<TEntity>()
               .Where(atributo + =".Contains(\"" + valor + "\")")
               .ToList()
    }
