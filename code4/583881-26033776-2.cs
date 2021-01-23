    public static class XManager 
    {
      static Dictionary<string, XDocument> __cache = new Dictionary<string, XDocument>();
      public static XDocument GetXDoc(string filepath)
      {
        if (!__cache.Contains(filepath)
        {
          __cache[filepath] = new XDocument();
          __cache[filepath].Load(filepath);
        }
        return _cache[filepath];
      }
    }
    
