    public sealed class MyValue
    {
      public MyValue(int value)
      {
        this.Value = value;
      } 
      public int Value { get; private set }
      public MyValue Add(int value)
      {
        return new MyValue(this.Value + value);
      }
    }
