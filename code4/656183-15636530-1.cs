    public static IList<FamilyLabel> Get(DbConnection connection, int depth)
    {
        var p = Expression.Parameter(typeof(FamilyLabel));
        Expression current = p;
    
        for (int i = 0; i < deep; i++)
        {
            current = Expression.Property(current, "Parent");
        }
    
        var nullConst = Expression.Constant(null, typeof(FamilyLabel));
    
        var predicate = Expression.Lambda<Func<FamilyLabel, bool>>(
            Expression.AndAlso(
                Expression.NotEqual(current, nullConst),
                Expression.Equal(Expression.Property(current, "Parent"), nullConst)), p);
    
        using (MyDbContext context = new MyDbContext(connection))
        {
            return context.FamilyLabels.Where(predicate).ToList();
        }
    }
