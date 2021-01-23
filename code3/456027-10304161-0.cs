    static BreedOfDog GetBreed(string name) 
    { 
      rwLock.EnterUpgradeableReadLock(); 
      try 
      { 
        BreedOfDog bd; 
        if (!Breeds.TryGetValue(name, out bd)) 
        { 
          rwLock.EnterWriteLock();
          try
          {
            if (!Breeds.TryGetValue(name, out bd))
            {
              bd = new BreedOfDog(name); 
              Breeds[name] = bd;
            }
          }
          finally
          {
            rwLock.ExitWriteLock();
          }
        } 
        return bd;
      } 
      finally 
      { 
        rwLock.ExitUpgradeableReadLock(); 
      } 
    }   
