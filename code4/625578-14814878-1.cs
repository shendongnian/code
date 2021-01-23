    interface IConverter
    {
      bool TryConvert(string obj, out object result);
    }
    
    class IntConvert : IConverter
    {
      public bool TryConvert(string obj, out object result) { /* stuff here */ }
    }
    
    class BoolConverter : IConverter {...}
    
    // etc.
    List<IConverter> converters = new List<IConverter>();
    converters.Add(new IntConvert());
    converters.Add(new BoolConvert());
    
    public static object ConvertToBestGuessPrimitive(string toConvert)
    {
      object obj;
      foreach(var converter in converters) {
        if(converter.TryConvert(toConvert, out obj))
           return obj;
      }
    
      return null;
    }
