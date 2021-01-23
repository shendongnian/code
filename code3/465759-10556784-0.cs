    struct MutableValueType
    {
      public int ChangableInt32;
    }
    static class Program
    {
      static void Main()
      {
         var li = new List<MutableValueType>();
         li.Add(new MutableValueType());
         li[0].ChangableInt32 = 42;
      }
    }
