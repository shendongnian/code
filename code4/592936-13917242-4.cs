        public void CollatzTest(int n)
        {
            var f = new Func<int, int>[] { i => i / 2, i => i * 3 + 1 };
            while (n != 1)
                n = f[n % 2](n);
        }
