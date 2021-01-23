    static string[] ToStringArray(object arg) {
      var collection = arg as System.Collections.IEnumerable;
      if (collection != null) {
        return collection
          .Cast<object>()
          .Select(x => x.ToString())
          .ToArray();
      }
      
      if (arg == null) {
        return new string[] { };
      }
    
      return new string[] { arg.ToString() };
    }
