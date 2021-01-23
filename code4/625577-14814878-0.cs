    interface IConverter
    {
      bool LooksLikeThis(string obj);
      object Convert(string obj);
    }
    
    class IntConvert : IConverter
    {
      bool LooksLikeThis(string obj) {return ... ;}
      object Convert(string obj) {return /* obj converted to int;*/ }
    }
    
    class BoolConverter : IConverter {...}
    
    // etc.
    List<IConverter> converters = new List<IConverter>();
    converters.Add(new IntConvert());
    converters.Add(new BoolConvert());
    
    public static object ConvertToBestGuessPrimitive(string toConvert)
    {
      foreach(var converter in converters)
        if(converter.LooksLikeThis(toConvert))
           return converter.Convert(toConvert);
    
      return null;
    }
