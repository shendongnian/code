    namespace MyNamespace
    {
       public class MyClass
       {
          public static readonly string IN_TABLE_KEY = "IN";
          public static readonly string OUT_TABLE_KEY = "OUT";
          public static readonly string TODAY_TABLE_KEY = "TODAY";
          public static readonly Dictionary<string, string> TEST = 
              new Dictionary<string, string>()
                 {
                    { IN_TABLE_KEY, "TEST1" },
                    { OUT_TABLE_KEY, "TEST2" },
                    { TODAY_TABLE_KEY, "TEST3" }
                 };
       }
    } 
