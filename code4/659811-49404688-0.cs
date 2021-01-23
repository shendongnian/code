        public static bool IsPrime(long n)
        {
            if (n == 1) return false;
            if (n == 3) return true;
            return !Enumerable.Range(2, Convert.ToInt32(Math.Ceiling(Math.Sqrt(n))))
                .Any(x => n % x == 0);
        }
     
