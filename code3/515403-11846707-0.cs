        public static bool ConformsToPattern(System.Numerics.BigInteger number)
        {
            byte[] ByteArray = number.ToByteArray();
            Regex BinaryRegex = new Regex("^(?:1*)(?:0+)$", RegexOptions.Compiled);
            return ByteArray.Where<byte>(x => !BinaryRegex.IsMatch(Convert.ToString(x, 2))).Count() > 0;
        }
