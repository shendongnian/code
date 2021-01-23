        public static string ToHexString(this byte[] bytes)
        {
            return bytes == null ? string.Empty : BitConverter.ToString(bytes).Replace("-", string.Empty);
        }
        public static byte[] FromHexString(this string hexString)
        {
            if (hexString == null)
            {
                return new byte[0];
            }
            var numberChars = hexString.Length;
            var bytes = new byte[numberChars / 2];
            for (var i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }
            return bytes;
        }
