    public struct MyStruct
    {
      private int value = 42;
      public void Foo()
      {
        Console.WriteLine(value);
      }
    }
    
    static void Main()
    {
      object obj = new MyStruct();
      ((MyStruct)obj).Foo();
    }
