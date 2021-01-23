        public static bool[] ByteToBitArray(int value)
        {
            bool[] ret = new bool[8];
            ret[0] = (value & 1) == 1;
            ret[1] = (value & 2) == 2;
            ret[2] = (value & 4) == 4;
            ret[3] = (value & 8) == 8;
            ret[4] = (value & 16) == 16;
            return ret;
        }
        public static bool Test(List<decimal> list, int comparer)
        {
            int variations = (int)(Math.Pow(2, list.Count) + 1);
            for (int i = 0; i < variations; i++)
            {
                decimal sum = 0;
                bool[] bits = ByteToBitArray(i);
                
                for (int bit = 0; bit < list.Count; bit++)
                {
                    if (bits[bit])
                    {
                        sum += list[bit];
                    }
                }
                if (sum == comparer) 
                { 
                    return true; 
                }
            }
            return false;
        }
        static void Main()
        {
            Console.WriteLine(Test(new List<decimal>() { 0.7m, 0.7m, 0.7m }, 1));
            Console.WriteLine(Test(new List<decimal>() { 0.7m, 0.3m, 0.7m }, 1));
            Console.ReadKey();
        }
