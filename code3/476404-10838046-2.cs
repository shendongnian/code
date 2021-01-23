    using System;
    namespace Test
    {
        public class Test
        {
            public static Int64 Noise(Int64 x) {
                 Int64 y = (Int64) ( (x << 13) ^ x);
                 Console.WriteLine(y.ToString());
                 Int64 t = (y * (y * y * 15731 + 789221) + 1376312589);
                 Console.WriteLine(t.ToString());
                 Int64 c = t < 0 ? -t : t; //( ((Int32)t) & 0x7fffffff);
                 Console.WriteLine("c = " + c.ToString());
                 double b = ((double)c) / 1073741824.0;
                 Console.WriteLine("b = " + b.ToString());
                 double t2 = ( 1.0 - b);
                 return (Int64)t2;
            }
            static void Main()
            {
            
               Int64 Seed = 1234;
               for(int i = 0 ; i < 3 ; i++)
               {
                   Seed = Noise(Seed);
                   Console.WriteLine(Seed.ToString());
               }
            }
        }
    }
