    public static class ObjectToDecimal
    {
      public static decimal? ToNullableDecimal(this object obj)
      {
        if(obj == null) return null;
        if(obj is string && String.Empty.Equals(obj)) return null;
        return Convert.ToDecimal(obj);
      }
    }
