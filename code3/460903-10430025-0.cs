    var result=from item in context.table
               select new{
                    field1=... ,
                    field2=... ,
                    field3=...
               };
    
    static IEnumerable<string> GetPropertyNames<T>(IEnumberable<T> lst) 
    {
      foreach (var pi in typeof(T).GetProperties())
      {
        yield return pi.Name;
      }
    }
    
    var propnames = GetPropertyNames(result);
