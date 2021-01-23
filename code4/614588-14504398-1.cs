    public static class LockersDBEntities1Extensions
    {
       public static int GetNextNumber<T>(
            this LockersDBEntities1 context, 
            Expression<Func<T, int>> getNumberExpression)
       {
         var query = (from item in context.Set<T> 
                      select getNumberExpression(item))
                     .DefaultIfEmpty(0)
                     .Max();
         return (int)query + 1;
        }
    }
