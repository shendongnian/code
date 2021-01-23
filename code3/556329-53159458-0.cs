    public static class ExtensionMethods
    {
        public static string MicrochipDataString(this string input)
        {
            int TwosComplement(string s)
            {
                if (s.Length % 2 != 0)
                    throw new FormatException(nameof(input));
                var checksum = 0;
                for (var i = 0; i < s.Length; i += 2)
                {
                    var value = int.Parse(s.Substring(i, 2), NumberStyles.AllowHexSpecifier);
                    checksum = (checksum + value) & 0xFF;
                }
                return 256 - checksum & 0xFF;
            }
            return string.Concat(":", input, TwosComplement(input).ToString("X2"));
        }
    }
