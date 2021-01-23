    public static Type GetTypeWithAttributeValue<TAttribute>(Assembly aAssembly, Func<TAttribute, object> pred, object oValue) {
      foreach (Type type in aAssembly.GetTypes()) {
        foreach (TAttribute oTemp in type.GetCustomAttributes(typeof(TAttribute), true)) {
          if (Equals(pred(oTemp), oValue)) {
            return type;
          }
        }
      }
      return typeof(string); //otherwise return a string type
    }
