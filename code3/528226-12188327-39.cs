        public static BigInteger Ackermann(BigInteger m, BigInteger n)
        {
        restart:
            if (m == 0)
                return  n+1;
            if (n == 0)
            {
                m--;
                n = 1;
                goto restart;
            }
            else
                return Ackermann(m - 1, Ackermann(m, n - 1));
        }
