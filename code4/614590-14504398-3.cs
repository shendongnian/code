    public static class LockersDBEntities1Extensions
    {
       public static int GetNextNumber<T>(this LockersDBEntities1 context)
                         where T:ILockNumberProvider 
       {
         var query = (from item in context.Set<T> 
                      select item.Number)
                     .DefaultIfEmpty(0)
                     .Max();
         return (int)query + 1;
        }
    }
