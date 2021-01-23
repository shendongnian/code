    namespace ClassLibrary1
    {
     public class Class1
     {
      public static string operator +(Class1 class1, double d)
      {
       return "a";
      }
      public static string operator +(double d, Class1 class1)
      {
       return "b";
      }
      public static string operator +(Class1 class1, Class1 class12)
      {
       return "c";
      }
     }
    }
