        class MyEqualityComparer : IEqualityComparer<int[]>
        {
            public bool Equals(int[] item1, int[] item2)
            {
                if (item1 == null && item2 == null)
                    return true;
                if ((item1 != null && item2 == null) ||
                        (item1 == null && item2 != null))
                    return false;
                return item1.SequenceEqual(item2);
            }
            public int GetHashCode(int[] item)
            {
                if(item == null)
                {
                    return int.MinValue;
                }
                int hc = item.Length;
                for (int i = 0; i < item.Length; ++i)
                {
                    hc = unchecked(hc * 314159 + item[i]);
                }
                return hc;
            }
        }
