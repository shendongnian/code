        public static UInt64 GetNthFibonacciNumber(uint n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            UInt64 a = 1, b = 1;
            uint i = 2;
            while (i <= n)
            {
                if (a > b) b += a;
                else a += b;
                ++i;
            }
            return (a > b) ? a : b;
        }
