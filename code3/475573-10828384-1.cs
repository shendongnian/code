    public List<IFoo> GetFoos<T>(Expression<Func<T, bool>> predicate) where T : class, IModel 
    {
        var result = new List<IFoo>();
        var repository = new Repository<T>();
        result.AddRange(repository.GetEntities(predicate).ToList().ConvertAll(c => (IFoo)c));
        return result;
    }
