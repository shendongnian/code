    public interface ICache
    {
      //Get item from cache
      object Get(string pName);
      //Check an item exist in cache
      bool Contains(string pName);
      //Add an item to cache
      void Add(string pName, object pValue);
      //Remove an item from cache
      void Remove(string pName);
    }
