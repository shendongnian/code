    IList<T> items;
    IEnumerable<T> itemsToDelete;
    ...
    {
       if(items.Equals(itemsToDelete)) //Equal lists?
         {
          items.Clear(); 
          return true;
         }
       
       if(  (double) items.Count/itemsToDelete.Count < 1){
          /* It is faster to iterate the small list first. */ 
                  foreach (var x in items)
                  {
                    if(itemsToDelete.Contains(x)){/**/} 
                     
                  }
        }
       else{
               foreach (var x in itemsToDelete)
                  {
                   items.Remove(x);
                  }
       }
    }
