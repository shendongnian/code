    public static class BigIntExtensions
    {
        private static List<BigInteger> powersOfTen;
        // Must be called before ToStringMt()
        public static void InitPowersOfTen(BigInteger n)
        {
            powersOfTen = new List<BigInteger>();
            powersOfTen.Add(1);
            for (BigInteger i = 10; i < n; i *= i)
                powersOfTen.Add(i);
        }
        public static string ToStringMT(this BigInteger n)
        {
            // compute the index into the powersOfTen table for the given parameter. This is very fast.
            var m = (int)Math.Ceiling(Math.Log(BigInteger.Log10(n), 2));
            BigInteger r1;
            // the largest amount of execution time happens right here:
            BigInteger q1 = BigInteger.DivRem(n, BigIntExtensions.powersOfTen[m], out r1);
            // split the remaining work across 4 threads - 3 new threads plus the current thread
            var t1 = Task.Factory.StartNew<string>(() =>
            {
                BigInteger r1r2;
                BigInteger r1q2 = BigInteger.DivRem(r1, BigIntExtensions.powersOfTen[m - 1], out r1r2);
                var t2 = Task.Factory.StartNew<string>(() => BuildString(r1r2, m - 2));
                return BuildString(r1q2, m - 2) + t2.Result;
            });
            BigInteger q1r2;
            BigInteger q1q2 = BigInteger.DivRem(q1, BigIntExtensions.powersOfTen[m - 1], out q1r2);
            var t3 = Task.Factory.StartNew<string>(() => BuildString(q1r2, m - 2));
            var sb = new StringBuilder();
            sb.Append(BuildString(q1q2, m - 2));
            sb.Append(t3.Result);
            sb.Append(t1.Result);
            return sb.ToString();
        }
        // same as ToQuickString, but bails out before m == 0 to reduce call overhead.
        // BigInteger.ToString() is faster than DivRem for smallish numbers.
        private static string BuildString(BigInteger n, int m)
        {
            if (m <= 8)
                return n.ToString();
            BigInteger remainder;
            BigInteger quotient = BigInteger.DivRem(n, powersOfTen[m], out remainder);
            return BuildString(quotient, m - 1) + BuildString(remainder, m - 1);
        }
    }
