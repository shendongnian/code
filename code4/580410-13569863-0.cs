    using System;
    public class FindLCM
    {
        public static int determineLCM(int a, int b)
        {
            int num1, num2;
            if (a > b)
            {
                num1 = a; num2 = b;
            }
            else
            {
                num1 = b; num2 = a;
            }
    
            for (int i = 1; i <= num2; i++)
            {
                if ((num1 * i) % num2 == 0)
                {
                    return i * num1;
                }
            }
            return num2;
        }
    
        public static void Main(String[] args)
        {
            int n1, n2;
    
            Console.WriteLine("Enter 2 numbers to find LCM");
    
            n1 = int.Parse(Console.ReadLine());
            n2 = int.Parse(Console.ReadLine());
    
            int result = determineLCM(n1, n2);
    
            Console.WriteLine("LCM of {0} and {1} is {2}",n1,n2,result);
            Console.Read();
        }
    }
