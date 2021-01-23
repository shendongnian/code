    public class MyClass
    {
      internal MyClass()
      {
        // ... code here ...
      }
    }
    public class MyFactory
    {
      public MyClass GetInstanceOfMyClass()
      {
        return new MyClass();
      }
    }
