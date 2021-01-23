    public static Foo GetByIdIncluding(long id, 
                     params Expression<Func<Foo, object>>[] includeProperties)
    {
        return Including(includeProperties).SingleOrDefault(f => f.Id == id);
    }
