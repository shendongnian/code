    using System;
    namespace Test
    {
        public class Test
        {
            /// Your function
            public static int Noise(int x) {
                double y = Math.Pow( (double)(x << 13), (double)x);
                double t = (y * (y * y * 15731.0 + 789221.0) + 1376312589.0);
                t = ( 1.0 - ((double)( ((int)t) & 0x7fffffff)) / 1073741824.0);
                return (int)t;
            }
            static void Main()
            {
                 int Seed = 12345678;
                 for(int i = 0 ; i < 10 ; i++)
                 {
                     Seed = Noise(Seed);
                     Console.WriteLine(Seed.ToString());
                 }
            }
        }
    }
