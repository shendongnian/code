    public static void EditEntity<TEntity>(this DbContext context, TEntity entity, TypeOfEditEntityProperty typeOfEditEntityProperty, params string[] properties)
       where TEntity : class
    {
        var find = context.Set<TEntity>().Find(entity.GetType().GetProperty("Id").GetValue(entity, null));
        if (find == null)
            throw new Exception("id not found in database");
        if (typeOfEditEntityProperty == TypeOfEditEntityProperty.Ignore)
        {
            foreach (var item in entity.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetProperty))
            {
                if (!item.CanRead || !item.CanWrite)
                    continue;
                if (properties.Contains(item.Name))
                    continue;
                item.SetValue(find, item.GetValue(entity, null), null);
            }
        }
        else if (typeOfEditEntityProperty == TypeOfEditEntityProperty.Take)
        {
            foreach (var item in entity.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetProperty))
            {
                if (!item.CanRead || !item.CanWrite)
                    continue;
                if (!properties.Contains(item.Name))
                    continue;
                item.SetValue(find, item.GetValue(entity, null), null);
            }
        }
        else
        {
            foreach (var item in entity.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetProperty))
            {
                if (!item.CanRead || !item.CanWrite)
                    continue;
                item.SetValue(find, item.GetValue(entity, null), null);
            }
        }
        context.SaveChanges();
    }
    public enum TypeOfEditEntityProperty
    {
        Ignore,
        Take
    }
