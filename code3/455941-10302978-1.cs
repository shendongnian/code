    class Program
    {
    
        private static double RoundFunction(uint input)
        {
            // Must be a function in the mathematical sense (x=y implies f(x)=f(y))
            // but it doesn't have to be reversible.
            // Must return a value between 0 and 1
            return ((1369 * input + 150889) % 714025) / 714025.0;
        }
        private static char Base62Digit(uint d)
        {
            if (d < 26)
            {
                return (char)('a' + d);
            }
            else if (d < 52)
            {
                return (char)('A' + d - 26);
            }
            else if (d < 62)
            {
                return (char)('0' + d - 52);
            }
            else
            {
                throw new ArgumentException("d");
            }
        }
        private static string ToBase62(uint n)
        {
            var res = "";
            while (n != 0)
            {
                res = Base62Digit(n % 62) + res;
                n /= 62;
            }
            return res;
        }
        private static uint PermuteId(uint id)
        {
            uint l1 = (id >> 16) & 65535;
            uint r1 = id & 65535;
            uint l2, r2;
            for (int i = 0; i < 3; i++)
            {
                l2 = r1;
                r2 = l1 ^ (uint)(RoundFunction(r1) * 65535);
                l1 = l2;
                r1 = r2;
            }
            return ((r1 << 16) + l1);
        }
    
    
        private static string GenerateCode(uint id)
        {
            return ToBase62(PermuteId(id));
        }
    
        static void Main(string[] args)
        {
    
            Console.WriteLine("testing...");
    
                try
                {
    
                    for (uint x = 1; x < 1000000; x += 1)
                    {
                        Console.Write(GenerateCode(x) + ",");
                            
                    }
                        
                }
                catch (Exception err)
                {
                    Console.WriteLine("error: " + err.Message);
                }
    
            Console.WriteLine("");
            Console.WriteLine("Press 'Enter' to continue...");
            Console.Read();
        }
    }
 
