    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace calculator_extended
    {
        class Program
        {
            static void Main(string[] args)
            {
                int d = 0;
    
                while (true)
                {
                    Console.WriteLine("Press A for addition");
                    Console.WriteLine("Press S for subtraction");
                    Console.WriteLine("Press M for Multiplication");
                    Console.WriteLine("Press D for Divide");
    
                    char c = Convert.ToChar(Console.ReadLine());
    
                    int a = Convert.ToInt32(Console.ReadLine());
                    int b = Convert.ToInt32(Console.ReadLine());
    
                    switch (c)
                    {
                        case 'A':
                        case 'a':
                            d = add(a, b);
                            Console.WriteLine(d);
                            break;
                        case 'S':
                        case 's':
                            d = sub(a, b);
                            Console.WriteLine(d);
                            break;
                        case 'M':
                        case 'm':
                            d = mul(a, b);
                            Console.WriteLine(d);
                            break;
                        case 'E':
                        case 'e':
                            d = div(a, b);
                            Console.WriteLine(d);
                            break;
                        case 'q':
                        case 'Q':
                            Application.Exit();
                        default:
                            Console.WriteLine("Please Enter the correct Character");
                            break;
                    }
                }
            }
            private static int add(int a, int b)
            {
    
                return a + b;
            }
            private static int sub(int a, int b)
            {
    
                return a - b;
            }
            private static int mul(int a, int b)
            {
                return a * b;
            }
            private static int div(int a, int b)
            {
    
                return a / b;
            }
    
        }
    }
