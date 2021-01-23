        class MyEqualityComparer : IEqualityComparer<int[]>
        {
            public bool Equals(int[] item1, int[] item2)
            {
                if (item1 == null && item2 == null)
                    return true;
                if ((item1 != null && item2 == null) ||
                        (item1 == null && item2 != null))
                    return false;
                if (item1.Length != item2.Length)
                {
                    return false;
                }
                for (int i = 0; i < item1.Length; i++)
                {
                    if (item1[i] != item2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            public int GetHashCode(int[] item)
            {
                int hc = item.Length;
                for (int i = 0; i < item.Length; ++i)
                {
                    hc = unchecked(hc * 314159 + item[i]);
                }
                return hc;
            }
        }
