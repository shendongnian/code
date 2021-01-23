    class Program
    {
        private static Random random = new Random();
    
    
        private static char Base62Digit(int d)
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
    
        static string ToBase62(int n)
        {
            var res = "";
            while (n != 0)
            {
                res = Base62Digit(n % 62) + res;
                n /= 62;
            }
            return res;
        }
    
    
        private static string GenerateCode(int id)
        {
    
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            
            var initialCode = new string(
                Enumerable.Repeat(chars, 4)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
    
            string unshuffled = initialCode + ToBase62(id).ToUpper();
    
    
            string codeWithID = new string(
                unshuffled.ToCharArray()
                .OrderBy(s => (random.Next(2) % 2) == 0)
                .ToArray());
    
    
            return codeWithID;
    
        }
    
        static void Main(string[] args)
        {
    
            Console.WriteLine("testing...");
    
                try
                {
    
                    for (int x = 1; x < 1000; x+=1)
                    {
                        
                        Console.Write(GenerateCode(x) + ",");
                    }
                    
                }
                catch (Exception err)
                {
                    Console.WriteLine("error: " + err.Message);
                }
    
    
            Console.WriteLine("Press 'Enter' to continue...");
            Console.Read();
        }
    }
