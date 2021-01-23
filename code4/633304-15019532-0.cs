    class ZeroIsBigComparer : System.Collections.Generic.IComparer<ulong>
        {
            public int Compare(ulong x, ulong y)
            {
                if (x == y) return 0;
                if (x == 0) return 1;
                if (y == 0) return -1;
                return x.CompareTo(y);
            }
        }
