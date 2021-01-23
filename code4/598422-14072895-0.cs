    using System;
    
    namespace ConsoleApplication4
    {
        class Member
        {
            public string Line1 { get; set; }
            public string Line2 { get; set; }
            public string Line3 { get; set; }
        }
    
        static class Program
        {
    
            private static void Main()
            {
    
                Member m = new Member {Line1 = "line1", Line2 = "line2", Line3 = "line3"};
    
                var value = GetPropValue(m, "Line1");
                // value here will be a type of System.String and u can safely cast it to a string, but better check it for null reference.
                Console.Read();
    
            }
            public static object GetPropValue(object src, string propName)
            {
                return src.GetType().GetProperty(propName).GetValue(src, null);
            }
        }
    
    }
    
