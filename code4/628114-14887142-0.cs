    public static string GetTableName<TEntity>(this Table<TEntity> MyTable) where TEntity : class
        {
            string name;
            Type type;
            type = typeof(TEntity);
            name = (type.GetCustomAttributes(typeof(TableAttribute), true)[0] as TableAttribute).Name;
            if (string.IsNullOrEmpty(name))
                return MyTable.Context.GetTable(type).ElementType.Name;
            else
                return name;
        }
