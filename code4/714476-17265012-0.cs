    static class Ext
    {
      static readonly Dictionary<YourType, int> fooValues = new Dictionary<YourType, int>();
      public static int GetFoo(this YourType yt)
      {
        int value;
        fooValues.TryGetValue(yt, out value);
        return value;
      }
      public static void SetFoo(this YourType yt, int value)
      {
        fooValues[yt] = value;
      }
    }
