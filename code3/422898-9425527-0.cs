    public static IEnumerable<TSelect> 
               GetFilteredSubset<TEntity, TSelect>(IEnumerable<TEntity> collection,
                                                   Func<TEntity, bool> filter)
            where TSelect : class, new()
        {
            IEnumerable<TSelect> result = collection.Where(filter)
                .Select(s => new TSelect().InjectFrom(s))
                .Cast<TSelect>();
            return result;
        }
