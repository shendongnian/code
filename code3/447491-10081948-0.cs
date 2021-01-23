    public TResult GetById<TResult, TEntity>(int id)
    {
        using (DBEntities dbe = new DBEntities())      
        {        
            T result = dbe.StoreTables.Set<T>.Find(new object[] {key});
            var mapper = ObjectMapperManager.DefaultInstance
                .GetMapper<TEntity, TResult>(
                   new DefaultMapConfig().MatchMembers((m1, m2) => "p_" + m1.ToLower() == m2));
            return mapper.Map(result);      
        }
    }
