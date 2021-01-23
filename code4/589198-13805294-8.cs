    using System;
    using System.Collections.Generic;
    
    namespace Net2Library
    {
        public class Class1
        {
            public static List<string> GetStrings()
            {
                var strings = new List<string>();
                Console.WriteLine("From Net2Library: {0}", strings.GetType().AssemblyQualifiedName);
                return strings;
            }
        }
    }
