        /// <summary>
        /// Calculates the binomial coefficient (nCk) (N items, choose k)
        /// </summary>
        /// <param name="n">the number items</param>
        /// <param name="k">the number to choose</param>
        /// <returns>the binomial coefficient</returns>
        public static long BinomCoefficient(long n, long k)
        {
            if (k > n) { return 0; }
            if (n == k) { return 1; } // only one way to chose when n == k
            if (k > n - k) { k = n - k; } // Everything is symmetric around n-k, so it is quicker to iterate over a smaller k than a larger one.
            long c = 1;
            for (long i = 1; i <= k; i++)
            {
                c *= n--;
                c /= i;
            }
            return c;
        }
