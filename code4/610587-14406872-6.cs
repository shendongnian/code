    public static IEnumerable<T> flatten(this T[][] items)
    {
       foreach(T[] nested in items)
       {
          foreach(T item in nested)
          {
             yield return item;
          }
       }
    }    
