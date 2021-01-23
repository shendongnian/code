    static class ClassA
    {
     string temp = Functions.Test();
     public static string Process()
     {
          return temp;
     }
    }
    static class Functions
    {
     public static string Test()
     {
          return "ok";
     }
    }
