    HashSet<string> secondary = new HashSet<string>(/*StringComparer.InvariantCultureIgnoreCase*/);
    Dictionary<int, string>dictionary = new Dictionary<int, string>();
    object syncer = new object();
    
    public override void Add(int key, string value)
    {
      lock(syncer)
      {
        if(dictionary.ContainsKey(key))
        {
          throw new Exception("Key already exists");
        }
    
        if(secondary.Add(value)
        {
          throw new Exception("Value already exists");
        }
        dictionary.Add(key, value);
      }
    }
