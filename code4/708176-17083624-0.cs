    using System;
    using System.Diagnostics;
    static class Program
    {
        static void Main()
        {
            // check our math first!
    
            // You can see 2345 is converted to 0 by using multiplication of digits in 2 steps
            int value, steps;
            value = MultiplyToOneDigit(2345, out steps);
            Debug.Assert(value == 0);
            Debug.Assert(steps == 2);
    
            // and it is converted to 5 by using addition of digits in 2 steps
            value = SumToOneDigit(2345, out steps);
            Debug.Assert(value == 5);
            Debug.Assert(steps == 2);
    
            // this bit is any random number
            var rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                int N = rand.Next(0, MAX);
                int result = Execute(N);
                Console.WriteLine("For N={0}, our answer is {1}", N, result);
            }
        }
        const int MAX = 1000000000;
        //Now consider any number N.
        static int Execute(int N)
        {
            // Let us say that it can be converted by multiplying digits to a one digit number d1 in n1
            // steps and by adding digits to one digit number d2 in n2 steps.
            int n1, n2;
            int d1 = MultiplyToOneDigit(N, out n1),
                d2 = SumToOneDigit(N, out n2);
    
            // Your task is to find smallest number greater than N and less than 1000000000 
            for (int i = N + 1; i < MAX; i++)
            {
                int value, steps;
    
                // which can be converted by multiplying its digits to d1 in less than or equal to n1 steps
                value = MultiplyToOneDigit(i, out steps);
                if (value != d1 || steps > n1) continue; // no good
    
                // and by adding its digits to d2 in less than or equal to n2 steps.
                value = SumToOneDigit(i, out steps);
                if(value != d2 || steps > n2) continue; // no good
    
                return i;
            }
            return -1; // no answer
        }
        static int MultiplyToOneDigit(int value, out int steps)
        {
            steps = 0;
            while (value > 10)
            {
                value = MultiplyDigits(value);
                steps++;
            }
            return value;
        }
        static int SumToOneDigit(int value, out int steps)
        {
            steps = 0;
            while (value > 10)
            {
                value = SumDigits(value);
                steps++;
            }
            return value;
        }
        static int MultiplyDigits(int value)
        {
            int acc = 1;
            while (value > 0)
            {
                acc *= value % 10;
                value /= 10;
            }
            return acc;
        }
        static int SumDigits(int value)
        {
            int total = 0;
            while (value > 0)
            {
                total += value % 10;
                value /= 10;
            }
            return total;
        }
    }
