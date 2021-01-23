    public class MyClass
    {
      public static MyClass GetCurrent()
      {
        if (SomeSortOfCache['MyClass.Current'] == null) {
          // do something to get populate it.
        }
        return SomeSortOfCache['MyClass.Current'];
      }
    }
