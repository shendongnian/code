    static class City
    {
       static bool _loaded = false;
    
       public bool Loaded { get { return _loaded; } }
       
       public static List<C> Data
       {
          get
          {
             if (!_loaded)
             {
                 doLoading();
                 _loaded = true
             }
          }
       }
    }
