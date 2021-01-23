    using System;
    namespace Test
    {
        public class Test
        {
            /// Your function.
            /// Fixed constants and bitwise ops
            public static int Noise(int x) {
                 Int32 y = (Int32) ( (x << 13) ^ x);
                 // Console.WriteLine(y.ToString());
                 Int32 t = (y * (y * y * 15731 + 789221) + 1376312589);
                 // Console.WriteLine(t.ToString());
                 /// Looks like signed/unsigned trickery
                 Int32 c = t < 0 ? -t : t; //( ((Int32)t) & 0x7fffffff);
                 // Console.WriteLine("c = " + c.ToString());
                 double b = ((double)c) / 1073741824.0;
                 // Console.WriteLine("b = " + b.ToString());
                 double t2 = ( 1.0 - b);
                 return (int)t2;
            }
  
            static void Main()
            {
                 int Seed = 1234;
                 for(int i = 0 ; i < 10 ; i++)
                 {
                     Seed = Noise(Seed);
                     Console.WriteLine(Seed.ToString());
                 }
            }
        }
    }
