    using System;
    class Program
    {
        static void Main(string[] args)
        {
            int x = 2;
            int y = 20;
            Console.WriteLine(Add(x, y));
            // x is still 2, y is still 20
        }
    
        static int Add(int x, int y)
        {
            int ans = x + y;
            // You calculate the parameters and store it in the local variable
            x = 20;
            y = 40;
            // You've adapted your local COPIES of the variables
            return ans;
            // You return the answer which was calculated earlier
        }
    }
