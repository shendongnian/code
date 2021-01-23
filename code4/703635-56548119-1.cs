        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            byte[] c = new byte[] { 0 };
            for (int i = 0; i < a.Length; i++)
                diff |= (uint)(GetElem(a, i, c, 0) ^ GetElem(b, i, c, 0));
            return diff == 0;
        }
        private static byte GetElem(byte[] x, int i, byte[] c, int i0)
        {
            bool ok = (i < x.Length);
            return (ok ? x : c)[ok ? i : i0];
        }
