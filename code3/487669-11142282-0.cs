    public class MyClass : ICloneable
    {
      private int myValue;
    
      public MyClass(int val)
      {
         myValue = val;
      }
    
      public void object Clone()
      {
         return new MyClass(myValue);
      }
    }
