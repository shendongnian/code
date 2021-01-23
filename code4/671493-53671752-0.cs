	public static class StringSupport
    {
        private static readonly int _charSize = sizeof(char);
        public static unsafe byte[] GetBytes(string str)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));
			if (str.Length == 0) return new byte[0];
			
            fixed (char* p = str)
            {
                return new Span<byte>(p, str.Length * _charSize).ToArray();
            }
        }
        public static unsafe string GetString(byte[] bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            if (bytes.Length % _charSize != 0) throw new ArgumentException($"Invalid {nameof(bytes)} length");
            if (bytes.Length == 0) return string.Empty;
            fixed (byte* p = bytes)
            {
                return new string(new Span<char>(p, bytes.Length / _charSize));
            }
        }
    }
	
