    class MyClass
    {
      // we choose to make the instance constructor private
      MyClass()
      {
      }
      // nested type, private to MyClass, deriving from MyClass
      class InnerMyClass : MyClass
      {
        // ...
      }
      public static MyClass GetMyClassInstance()
      {
        return new InnerMyClass();
      }
      // ...
    }
