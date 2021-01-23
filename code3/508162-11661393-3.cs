    private object GetUpdateList(string tableName, int id, DataClassesDataContext db)
    {
        System.Reflection.PropertyInfo pi = db.GetType().GetProperty(tableName);
        var table = pi.GetValue(db, null);
        // Get type of object within the table.
        Type genericType = table.GetType().GetGenericArguments()[0];
        var param = Expression.Parameter(genericType, "x");
        var predicateExpr = Expression.Lambda(
            Expression.GreaterThan(
                Expression.Property(param, "Id"),
                Expression.Constant(id)),
            param);
        
        return this
            .GetType()
            .GetMethod("GetUpdateListGeneric")
            .MakeGenericMethod(genericType)
            .Invoke(this, new[] { table, predicateExpr });
    }
    private IList<T> GetUpdateListGeneric<T>(
        Table<T> table, 
        Expression<Func<T, bool>> predicate) where T : class
    {
        return table.Where(predicate).ToList();
    }
