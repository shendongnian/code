    public static class MyBigOClassOHelpfulStaticMethods //maybe pick a better name
    {
      public static MyCustomList ToMyCustomList(this IEnumerable<MyCustomList> source)
      {
        return new MyCustomList(source);
      }
    }
