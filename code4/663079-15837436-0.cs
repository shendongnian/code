    using System;
    using System.Linq;
    using System.Collections.Generic;
    namespace Demo
    {
        static class Program
        {
            static void Main()
            {
                var obj = new object();
                int count = AllParents(obj).Count(); // Using Linq only here.
                Console.WriteLine(count);
            }
            public static IEnumerable<object> AllParents(object obj)
            {
                while (true)
                {
                    obj = GetParentObject(obj);
                    if (obj == null)
                        yield break;
                    yield return obj;
                }
            }
            // This is merely a hacky test implementation.
            public static object GetParentObject(object obj)
            {
                if (--count == 0)
                    return null;
                return obj;
            }
            private static int count = 10;
        }
    }
