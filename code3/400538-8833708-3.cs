    public static IEnumerable<string> FavourWWWDistinct(IEnumerable<string> src)
    {
      Dictionary<string, bool> dict = new Dictionary<string, bool>(new IgnoreWWWEqComparer());
      foreach(string str in src)
      {
        bool withWWW;
        if(dict.TryGetValue(str, out withWWW))
        {
          if(withWWW)
            continue;
          if(str.StartsWith("www."))
          {
            dict[str] = true;
            yield return str;
          }
        }
        else
        {
          if(dict[str] = str.StartsWith("www."))
            yield return str;
        }
      }
      foreach(var kvp in dict)
        if(!kvp.Value)
          yield return kvp.Key;
    }
