        static bool IsPrime(int n)
        {
            if (n > 1)
            {
                return Enumerable.Range(1, n).Where(x => n%x == 0)
                                 .SequenceEqual(new[] {1, n});
            }
            return false;
        }
