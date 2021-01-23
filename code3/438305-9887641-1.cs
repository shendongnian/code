    using System;
    namespace ticket
    {
    class Program
    {
        public static int x = 0;
        static void LoopingFunction()
        {
            while (x <= 20)
            {
                int dwStartTime = System.Environment.TickCount;
                while (true)
                {
                    if (System.Environment.TickCount - dwStartTime > 100) break; //100 milliseconds 
                }
                Console.WriteLine(x);
                x++;
                if (x == 20)
                {
                    ///add "stuff"
                    Console.WriteLine("Test");
                    x = 0;
                }
            }
        }
        static void Main()
        {
            LoopingFunction();
            Console.Read();
           
        }
    }
    }
