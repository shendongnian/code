    using System;
    class Program
    {
        private class Numbers
        {
            public int X;
            public int Y;
        }
        static void Main(string[] args)
        {
            Numbers num = new Numbers();
            num.x = 2;
            num.y = 20;
            Console.WriteLine(Add(num)); // Prints 2 + 20 = 22
            // num.x is now 20, and num.y is now 40
            Console.WriteLine(Add(num)); // Prints 20 + 40 = 60
        }
    
        static int Add(Numbers num)
        {
            int ans = num.x + num.y;
            // You calculate the result from the public variables of the class
            num.x = 20;
            num.y = 40;
            // You change the values of the class
            return ans;
            // You return the answer which was calculated earlier
        }
    }
