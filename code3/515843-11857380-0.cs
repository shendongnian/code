    public static class Recorder
    {
      // overload for any method, that returns value
      public T CallFunc(Func<T> func)
      {
        // other stuff here
        return func();
        // other stuff here
      }
    
      // overload for any method, that returns void
      public static CallFunc(Action action)
      {
        // other stuff here
        action();
        // other stuff here
      }
    }
