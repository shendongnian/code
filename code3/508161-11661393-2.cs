    private IList GetUpdateList(string tableName, int id, DataClassesDataContext db)
    {
        System.Reflection.PropertyInfo pi = db.GetType().GetProperty(tableName);
        var table = pi.GetValue(db, null);
        // Get type of object within the table.
        Type genericType = table.GetType().GetGenericArguments()[0];
        var predicateExpr = Expression.Lambda(
            Expression.GreaterThan(
                Expression.Property(Expression.Parameter(genericType, "x"), "Id"),
                Expression.Constant(id)),
            Expression.Parameter(genericType, "x"));
        
        return this
            .GetType()
            .GetMethod("GetUpdateListGeneric")
            .MakeGenericMethod(genericType)
            .Invoke(this, new[] { table, predicateExpr }) as IList;
    }
    private IList<T> GetUpdateListGeneric<T>(
        Table<T> table, 
        Expression<Func<T, bool>> predicate)
    {
        return table.Where(predicate).ToList();
    }
