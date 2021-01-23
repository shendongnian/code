    static void Main(string[] args)
        {
            int PPwr_Count = 1; //number 1 is included by default.
            int Top_Limit = 1000000000; //Can be any number up to 10^9
            HashSet<int> hs = new HashSet<int>();
            for (int A = 2; A * A <= Top_Limit; ++A)
            {
                if (!hs.Contains(A))
                {
                    //We use long because of possible overflow
                    long t = A*A;
                    while (t <= Top_Limit)
                    {
                        hs.Add((int)t);
                        t *= A;
                        PPwr_Count++;
                    }
                }
            }
            Console.WriteLine(PPwr_Count);
        }
