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
                // Prints False
                bool result = test.AnyIn("other", "value");
                Console.WriteLine(result.ToString()); 
                // Prints True
                result = test.AnyIn("other", "The");
                Console.WriteLine(result.ToString()); 
                //  No Assert dialog here 
                System.Diagnostics.Debug.Assert(test.AnyIn("other", "The"), "No expected values found");
                //  Big Assert dialog here with message "No expected values found"
                System.Diagnostics.Debug.Assert(test.AnyIn("other", "The"), "No expected values found");
            }
    
        }
    
        static class ext
        {
            public static bool AnyIn(this string s, params string[] values)
            {
                return values.Any(x => s.Contains(x));
            }
        }
    }
