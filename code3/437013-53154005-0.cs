    public T? GetParsedOrDefaultValue<T>(string valueToParse) where T : struct, IComparable
    {
     if(string.EmptyOrNull(valueToParse))return null;
      try
      {
         // return parsed value
         return (T) Convert.ChangeType(valueToParse, typeof(T));
      }
      catch(Exception)
      {
       //default as null value
       return null;
      }
     return null;
    }
