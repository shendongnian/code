        public static void ClearArray(Array a, int val)
        {
            int[] indices = new int[a.Rank];
            ClearArray(a, 0, indices, val);
        }
        private static void ClearArray(Array a, int r, int[] indices, int v)
        {
            for (int i = 0; i < a.GetLength(r); i++)
            {
                indices[r] = i;
                if (r + 1 < a.Rank)
                    ClearArray(a, r + 1, indices, v);
                else
                    a.SetValue(v, indices);
            }
        }
