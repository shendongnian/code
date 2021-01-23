    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplicationSplit
    {
        class Program
        {
            static void Main(string[] args)
            {
                float f = 6.3f;
                var arr = GetElegantRange(f).OrderBy(_ => _).ToArray();
                foreach (var item in arr)
                {
                    Console.WriteLine(item);
                }
            }
    
            public static IEnumerable<float> GetElegantRange(float input)
            {
                while (input > 0)
                {
                    yield return input--;
                }
            }
        }
    }
