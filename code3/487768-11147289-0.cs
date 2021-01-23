    public void Clear()
    {
       var itemsToRemove = new List<string>();
    
       var enumerator = HttpContext.Current.Cache.GetEnumerator();
       while (enumerator.MoveNext())
       {
          itemsToRemove.Add(enumerator.Key.ToString());
       }
    
       foreach (string itemToRemove in itemsToRemove)
       {
          HttpContext.Current.Cache.Remove(itemToRemove);
       }
    }
