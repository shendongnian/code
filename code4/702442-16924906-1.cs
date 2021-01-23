    protected void Process(int count, int id)
    {
        var query = session.Query<A>().Where(BuildFilter(count,id));
        var result = query.ToList();
    }
    private static Expression<Func<A, bool>> BuildFilter(int count, int id)
    {
       var x = Expression.Parameter(typeof(A), "x");
       
       Expression instance = x;
       if (count != 0)
       {
          var prop = typeof(A).GetProperty("ParentA");
          while (count > 0)
          {
             instance = Expression.Property(instance, prop);
             count--;
          }
       }
       
       var instanceId = Expression.Property(instance, "Id");
       var compareId = Expression.Constant(id);
       var body = Expression.Equal(instanceId, compareId);
       
       return Expression.Lambda<Func<A, bool>>(body, x);
    }
