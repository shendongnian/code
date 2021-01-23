    public class MyClass
    {
      public static MyClass Current
      {
        get
        {
          if (SomeSortOfCache['MyClass.Current'] == null) {
            // do something to get populate it.
          }
          return SomeSortOfCache['MyClass.Current'];
        }
      }
    }
