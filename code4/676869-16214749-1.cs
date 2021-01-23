    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            private static void Main()
            {
                var test = new Test
                {
                    Str1 = "S1",
                    Str2 = "S2",
                    Str3 = "S3",
                    Str4 = "S4"
                };
                foreach (var property in PropertiesOfType<string>(test))
                {
                    Console.WriteLine(property.Key + ": " + property.Value);
                }
            }
            public static IEnumerable<KeyValuePair<string, T>> PropertiesOfType<T>(object obj)
            {
                return from p in obj.GetType().GetProperties()
                        where p.PropertyType == typeof(T)
                        select new KeyValuePair<string, T>(p.Name, (T)p.GetValue(obj));
            }
        }
        public class Test
        {
            public string Str1 { get; set; }
            public string Str2 { get; set; }
            public string Str3 { get; set; }
            public string Str4 { get; set; }
        }
    }
