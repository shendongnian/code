    using System;
    
    namespace ConsoleApplication24
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Which method would you like to run?");
                RunMyMethod(Console.ReadLine());
            }
    
            private static void RunMyMethod(string p)
            {
                switch (p)
                {
                    case "MethodOne();":
                        MethodOne();
                        break;
                    case "MethodTwo();":
                        MethodTwo();
                        break;
                    case "MethodThree();":
                        MethodThree();
                        break;
                }
            }
    
            private static void MethodThree()
            {
                //Do Stuff
            }
    
            private static void MethodTwo()
            {
                //Do Stuff
            }
    
            private static void MethodOne()
            {
                //Do Stuff
            }
        }
    }
