        public static string GetTableName<TEntity>(this Table<TEntity> MyTable) where TEntity : class
        {
            string name = string.Empty;
            Type type;
            object[] attributes;
    
            type = typeof(TEntity);
            attributes = type.GetCustomAttributes(typeof(TableAttribute), true);
    
            if (attributes.Length > 0)
                name = ((TableAttribute)attributes[0]).Name;
                if (!string.IsNullOrEmpty(name))
                    return name;
    
             return type.Name;
        }
