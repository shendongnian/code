    public static bool Exists<TEntity>(this MyDataContext context, int id) 
    {
        // your code here, something similar to
        return context.Set<TEntity>().Any(x => x.Id == id);
        // or with reflection:
        return context.Set<TEntity>().Any(x => {
            var props = typeof(TEntity).GetProperties();
            var myProp = props.First(y => y.GetCustomAttributes(typeof(Key), true).length > 0)
            var objectId = myProp.GetValue(x)
            return objectId == id;
        });
    }
