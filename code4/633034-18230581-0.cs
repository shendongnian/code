    public static TEntity GetOriginal<TEntity>(this DbContext ctx, TEntity updatedEntity) where TEntity : class
        {
            Func<DbPropertyValues, Type, object> getOriginal = null;
            getOriginal = (originalValues, type) =>
                 {
                     object original = Activator.CreateInstance(type, true);
                     foreach (var ptyName in originalValues.PropertyNames)
                     {
                         var property = type.GetProperty(ptyName);
                         object value = originalValues[ptyName];
                         if (value is DbPropertyValues) //nested complex object
                         {
                             property.SetValue(original, getOriginal(value as DbPropertyValues, property.PropertyType));
                         }
                         else
                         {
                             property.SetValue(original, value);
                         }
                     }
                     return original;
                 };
            return (TEntity)getOriginal(ctx.Entry(updatedEntity).OriginalValues, typeof(TEntity));
        }
