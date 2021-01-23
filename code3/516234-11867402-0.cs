    public static IEnumerable<T> SortAndDedupe<T>(this IEnumerable<T> input)
    {
       var toDedupe = input.OrderBy(x=>x);
    
       T prev;
       foreach(var element in toDedupe)
       {
          if(element == prev) continue;
    
          yield return element;
          prev = element;      
       }
    }
    
    //Usage
    dtList  = dtList.Where(s => !string.IsNullOrWhitespace(s)).SortAndDedupe().ToList();
