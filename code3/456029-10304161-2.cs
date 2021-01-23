    static volatile Dictionary<string, BreedOfDog> Breeds = new Dictionary<string,BreedOfDog>();
    static readonly object LockObject = new object();
    
    static BreedOfDog GetBreed(string name)
    {
      BreedOfDog bd;
      if (!Breeds.TryGetValue(name, out bd))
      {
        lock (LockObject)
        {
          if (!Breeds.TryGetValue(name, out bd))
          {
            bd = new BreedOfDog(name);
            var copy = new Dictionary<string, BreedOfDog>(Breeds);
            copy[name] = bd;
            Breeds = copy;
          }
        }
      }
      return bd;
    }
