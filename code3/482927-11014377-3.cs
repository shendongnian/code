    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main()
            {
                string test = "The actual string";
                System.Diagnostics.Debug.Assert(test.In("other", "The"), "No expected values found");
            }
    
        }
    
        static class ext
        {
            public static bool In(this string s, params string[] values)
            {
                return values.Any(x => s.Contains(x));
            }
        }
    }
