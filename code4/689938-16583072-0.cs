    using System;
    namespace Demo
    {
        class Program
        {
            void Run()
            {
                float f1 = 353.58f;
                float f2 = 353.59f;
                if (Math.Abs(f1 - f2) == 0.01f)
                    Console.WriteLine("[A] YAY");
                else
                    Console.WriteLine("[A] Oh dear"); // This gets printed.
                float target = 0.01f;
                float difference = Math.Abs(f2 - f1);
                float epsilon = 0.00001f; // Any difference smaller than this is ok.
                float differenceFromTarget = Math.Abs(difference - target);
                if (differenceFromTarget < epsilon) // This gets printed.
                    Console.WriteLine("[B] YAY");
                else
                    Console.WriteLine("[B] Oh dear"); 
            }
            static void Main()
            {
                new Program().Run();
            }
        }
    }
