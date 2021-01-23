    public class MyClass
    {
      public MyClass()
      {
        lazyGetSum = new Lazy<int>(GetSum);
      }
      public int X { get; set; }
      public int Y { get; set; }
      private Lazy<int> lazyGetSum;
      public int Sum { get { return lazyGetSum.Value; } }
      private int GetSum() { return X + Y; }
    }
