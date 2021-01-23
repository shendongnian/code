        static long nFactorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            long result = 1;
            try
            {
                for (int i = 1; i <= n; i++)
                {
                    result = checked(result * i); 
                }
            }
            catch (OverflowException)
            {
                return 0;
            }
            return result;
        }
