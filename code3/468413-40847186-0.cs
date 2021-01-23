        public static void DistinctValues<T>(List<T> list)
        {
            list.Sort();
            int src = 0;
            int dst = 0;
            while (src < list.Count)
            {
                var val = list[src];
                list[dst] = val;
                ++dst;
                while (++src < list.Count && list[src].Equals(val)) ;
            }
            if (dst < list.Count)
            {
                list.RemoveRange(dst, list.Count - dst);
            }
        }
