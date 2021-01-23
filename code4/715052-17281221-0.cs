    public static class BitArrayExtensions
    {
        public static string ToBitString(this BitArray encoded)
        {
            if (encoded == null)
            {
                return string.Empty;
            }
            var sb = new StringBuilder(encoded.Count);
            foreach (bool bit in encoded)
            {
                sb.Append(bit ? "1" : "0");
            }
            return sb.ToString();
        }
    }
