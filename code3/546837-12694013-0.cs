    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            private static int dimension = 1;
            public static int[] junkArray = new int[dimension];
    
            static void Main(string[] args)
            {
                Method1();
                Method2();
            }
    
            static void Method1()
            {
                int i = 0;
                junkArray[i] = (int)Math.Floor(-3.0002);
            }
    
            static void Method2()
            {
                int i = 0;
                int[] junkArray = new int[dimension];
                Console.WriteLine("final: " + (int)junkArray[i] + " test:" + (int)Math.Floor(-3.0002));
            }
        }
    }
