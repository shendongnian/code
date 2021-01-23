    using System;
    
    static class Extensions
    {
        static Extensions()
        {
            Console.WriteLine("Throwing exception");
            throw new Exception("Bang");
        }
        
        public static void Woot(this int x)
        {
            Console.WriteLine("Woot!");
        }
    }
    
    class Test
    {
        
        static void Main()
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    i.Woot();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Caught exception: {0}", e.Message);
                }
            }
        }
    }
