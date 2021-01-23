        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            byte[] c = new byte[] { 0 };
            for (int i = 0; i < a.Length; i++)
                diff |= (uint)(GetElem(a, c, i) ^ GetElem(b, c, i));
            return diff == 0;
        }
        private static byte GetElem(byte[] x, byte[] c, int i)
        {
            bool ok = (i < x.Length);
            return (ok ? x : c)[ok ? i : 0];
        }
