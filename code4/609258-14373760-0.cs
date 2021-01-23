        public void Add<T>(ref T[] ar, List<T> list)
        {
            int oldlen = ar.Length;
            Array.Resize<T>(ref ar, oldlen + list.Count);
            for (int i = 0; i < list.Count; ++i)
            {
                ar[oldlen + i] = list[i];
            }
        }
