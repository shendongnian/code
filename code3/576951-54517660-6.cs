    internal static class DecimalExtensions
    {
      public static byte GetScale(this decimal value)
      {
        unsafe
        {
          byte* v = (byte*)&value;
          return v[2];
        }
      }
    }
