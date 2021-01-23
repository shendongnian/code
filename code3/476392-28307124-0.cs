    public static class Interfacefunction{
      public static string GetDbConnectionType(this ICodeGenerator me)
      {
          // this is the method I would like to be static:
          // you can even get access to me
          return "SQLiteConnection";
      }
    }
