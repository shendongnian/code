    public static class Ext
    {
      public static void set(this YOUR_LIB_TYPE lib, object value)
      {
        if(value is int)
        {
          lib.set((int) value);
        }
        else if(value is string)
        {
          lib.set((string) value);
        }
        ...
      }
    }
