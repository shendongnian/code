    static class MyClassWrapper
    { 
       internal static void MyMethodWrapper(string name)
       {
          try
          {
             MyMethodWrapperImpl(name);
          }
          catch (MissingMethodException)
          {
             // do whatever you need to to make it work without the method.
             // this may go as far as re-implementing my method.
          }
       }
    
       private static void MyMethodWrapperImpl(string name)
       {
           MyClass.MyMethod(name);
       }   
    }
