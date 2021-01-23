    public static class Extensions
    {
        public static int Append(this int n, int i)
        {
            int p = 1;
            while (p < i) p = ((p << 2) + p) << 1;
            return x * p + i; 
        }
    }
