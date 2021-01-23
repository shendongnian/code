            int[] a1 = new int[] { 1, 2, 3, 2, 3, 1 };
            int[] a2 = new int[] { 1, 2, 3, 2, 3, 1, 3, 2, 3 };
            List<int> r = new List<int>();
            bool a1_longer = (a1.Length > a2.Length);
            int length_diff = Math.Abs(a1.Length - a2.Length);
            int length = (a1_longer ? a2.Length : a1.Length);
            for (int i = 0; i < length; i++) r.Add(a1[i] + a2[i]);
            for (int i = 0; i < length_diff; i++) {
                r.Add(a1_longer ? a1[length + i] : a2[length+i]);
            }
            r.ToArray();
