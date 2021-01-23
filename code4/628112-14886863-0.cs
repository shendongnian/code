    public static string GetTableName<TEntity>(this Table<TEntity> MyTable) 
                                where TEntity : class
    {
        Type type = typeof(TEntity);
        object[] temp = type.GetCustomAttributes(
                               typeof(System.Data.Linq.Mapping.TableAttribute), 
                               true);
        if (temp.Length == 0)
            return null;
        else
            return (temp[0] as System.Data.Linq.Mapping.TableAttribute).Name;
    }
