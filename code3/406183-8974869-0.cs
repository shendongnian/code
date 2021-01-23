        public static string GetRandomString(int length)
        {
            var rng = new RNGCryptoServiceProvider();
            var padded = (int)Math.Ceiling(length / 2.0m);
            var bytes = new byte[padded];
            rng.GetBytes(bytes);
            return bytes.Aggregate(new StringBuilder(), (f, s) => f.AppendFormat("{0:X2}", s)).ToString(0, length);
        }
