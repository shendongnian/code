    public class CusComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            x = x.OrderBy(i => i).ToArray();
            y = y.OrderBy(i => i).ToArray();
            for (int i = 0; i < Math.Min(x.Length, y.Length); i++ )
            {
                if (x[i] < y[i]) return -1;
                if (x[i] > y[i]) return 1;
            }
             if (x.Length < y.Length) return -1;
            if (x.Length > y.Length) return 1;
            return 0;
        }
    }
