    public static Type GetTypeWithAttributeValue<TAttribute>(Assembly aAssembly, Predicate<TAttribute> pred) {
      foreach (Type type in aAssembly.GetTypes()) {
        foreach (TAttribute oTemp in type.GetCustomAttributes(typeof(TAttribute), true)) {
          if (pred(oTemp)) {
            return type;
          }
        }
      }
      return typeof(string); //otherwise return a string type
    }
