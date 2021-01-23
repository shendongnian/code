    public static bool IsInt(this string pString)
    {
       int value;       
       return pString == null 
          ? false
          : int.TryParse(pString, out value);
    }
