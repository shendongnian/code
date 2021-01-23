    private static types = new HashTable<Type, SqlDbType>();
    public static SqlDbType GetSqlDbType(Type type)
    {
        if (types == null)
        {
            var types = new HashTable<Type, SqlDbType>();
            types.Add(int.GetType(), SqlDbType.Int);
            // And so forth...
        }
    
        return types[type];
    
    }
