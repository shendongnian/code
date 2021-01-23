    public class Foo
    {
      private Foo() { }
    
      public static Foo Create()
      {
        if(GetCallingType() != typeof(Bar))
        {
          throw new Exception("Only Bar can create Foo");
        }
        return new Foo();
      }
    
      private static Type GetCallingType()
      {
        return new StackFrame(2, false).GetMethod().DeclaringType;
      }
    }
