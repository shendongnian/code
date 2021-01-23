    public static string GetTableName<TEntity>(this Table<TEntity> MyTable) where TEntity : class
        {
            string name;
            Type type;
            type = typeof(TEntity);
            name = (type.GetCustomAttributes(typeof(TableAttribute), true)[0] as TableAttribute).Name;
            if (string.IsNullOrEmpty(name))
                return type.Name;
            else
                return name;
        }
