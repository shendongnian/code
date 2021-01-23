    public class MyClass
    {
      public MyClass()
      {
        LazyGetSumInit();
      }
      public int X { get; set; }
      public int Y { get; set; }
      private Lazy<int> lazyGetSum;
      public int Sum { get { return lazyGetSum.Value; } }
      private void LazyGetSumInit() { lazyGetSum = new Lazy<int>(new Func<int>(() => X + Y)); }
    }
