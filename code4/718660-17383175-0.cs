    // Enum display names
    public static class EnumDisplayNames {
      // Display name storage
      private static Dictionary<Type, Dictionary<Enum, String>> s_Names = 
        new Dictionary<Type, Dictionary<Enum, String>>();
    
      // Display name for the single enum's option
      private static String CoreAsDisplayName(Enum value) {
        Dictionary<Enum, String> dict = null;
    
        if (s_Names.TryGetValue(value.GetType(), out dict)) {
          String result = null;
    
          if (dict.TryGetValue(value, out result))
            return result;
          else
            return Enum.GetName(value.GetType(), value);
        }
        else
          return Enum.GetName(value.GetType(), value);
      }
    
      // Register new display name
      public static void RegisterDisplayName(this Enum value, String name) {
        Dictionary<Enum, String> dict = null;
    
        if (!s_Names.TryGetValue(value.GetType(), out dict)) {
          dict = new Dictionary<Enum, String>();
    
          s_Names.Add(value.GetType(), dict);
        }
    
        if (dict.ContainsKey(value))
          dict[value] = name;
        else
          dict.Add(value, name);
      }
      
      // Get display name
      public static String AsDisplayName(this Enum value) {
        Type tp = value.GetType();
    
        // If enum hasn't Flags attribute, just put vaue's name 
        if (Object.ReferenceEquals(null, Attribute.GetCustomAttribute(tp, typeof(FlagsAttribute))))
          return CoreAsDisplayName(value);
    
        // If enum has Flags attribute, enumerate all set options
        Array items = Enum.GetValues(tp);
    
        StringBuilder Sb = new StringBuilder();
    
        foreach (var it in items) {
          Enum item = (Enum) it;
    
          if (Object.Equals(item, Enum.ToObject(tp, 0)))
            continue;
    
          if (value.HasFlag(item)) {
            if (Sb.Length > 0)
              Sb.Append(", ");
            Sb.Append(CoreAsDisplayName(item));
          }
        }
    
        Sb.Insert(0, '[');
    
        Sb.Append(']');
    
        return Sb.ToString();
      }
    }
