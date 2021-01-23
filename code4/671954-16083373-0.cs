    public IDictionary<string, IEnumerable<string>> Name2Addresses    
    {
      get
      {
        return name2Addresses.ToDictionary(d => d.Key, d => d.Value.AsEnumerable());
      }
    }
