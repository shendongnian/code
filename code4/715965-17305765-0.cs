    public AccessModel GetAccess(string accessCode)
    {
         if(cache.Get<string>(accessCode) != null)
              return cache.Get<string>(accessCode);
    
         return GetFromDatabase(accessCode);
    }
