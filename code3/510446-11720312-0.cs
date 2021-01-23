    IDictionaryEnumerator enumerator = HttpContext.Current.Cache.GetEnumerator();    
    while (enumerator.MoveNext())
    {    
        HttpContext.Current.Cache.Remove(enumerator.Key);    
    }
