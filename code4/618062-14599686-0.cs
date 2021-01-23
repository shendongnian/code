        static void Main(string[] args)
        {
            int[] nums = Enumerable.Range(1, 20).ToArray();
            int lcm = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                lcm = LCM(lcm, nums[i]);
            }
            Console.WriteLine("LCM = {0}", lcm);
        }
        public static int LCM(int value1, int value2)
        {
            int a = Math.Abs(value1);
            int b = Math.Abs(value2);
            // perform division first to avoid potential overflow
            a = checked((a / GCD(a, b)));
            return checked((a * b));
        }
        public static int GCD(int value1, int value2)
        {
            int gcd = 1;     // Greates Common Divisor
            // throw exception if any value=0
            if (value1 == 0 || value2 == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            // assign absolute values to local vars
            int a = Math.Abs(value1);            // local var1
            int b = Math.Abs(value2);            // local var2
            // if numbers are equal return the first
            if (a == b) { return a; }
                // if var "b" is GCD return "b"
            if (a > b && a % b == 0) { return b; }
                // if var "a" is GCD return "a"
            if (b > a && b % a == 0) { return a; }
            // Euclid algorithm to find GCD (a,b):
            // estimated maximum iterations: 
            // 5* (number of dec digits in smallest number)
            while (b != 0)
            {
                gcd = b;
                b = a % b;
                a = gcd;
            }
            return gcd;
        }
    }
