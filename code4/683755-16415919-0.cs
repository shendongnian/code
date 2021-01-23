        int[] ArrTotal(int[] a, int[] b)
        {
            int length = Math.Max(a.Length, b.Length);
            int[] result = new int[length];
            for (int i = 0; i < length; i++)
            {
                int sum = 0;
                if (a.Length > i) sum += a[i];
                if (b.Length > i) sum += b[i];
                result[i] = sum;
            }
            return result;
        }
