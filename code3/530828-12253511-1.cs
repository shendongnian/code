    static class SafeParallel
    {
        public static bool AreEqual(byte[] a, byte[] b)
        {
            if (a == b)
                return true;
            if (a == null || b == null)
                return false;
            if (a.Length != b.Length)
                return false;
            bool b1 = false;
            bool b2 = false;
            bool b3 = false;
            bool b4 = false;
            int quarter = a.Length / 4;
            Parallel.Invoke(
                () => b1 = AreEqual(a, b, 0, quarter),
                () => b2 = AreEqual(a, b, quarter, quarter),
                () => b3 = AreEqual(a, b, quarter * 2, quarter),
                () => b4 = AreEqual(a, b, quarter * 3, a.Length)
            );
            return b1 && b2 && b3 && b4;
        }
        static bool AreEqual(byte[] a, byte[] b, int start, int length)
        {
            var len = length / 8;
            if (len > 0)
            {
                for (int i = start; i < len; i += 8)
                {
                    if (BitConverter.ToInt64(a, i) != BitConverter.ToInt64(b, i))
                        return false;
                }
            }
            var remainder = length % 8;
            if (remainder > 0)
            {
                for (int i = length - remainder; i < length; i++)
                {
                    if (a[i] != b[i])
                        return false;
                }
            }
            return true;
        }
    }
