        public static string LimitByteLength(string input, int startByte, int byteLength)
        {
            var maxLength = startByte + byteLength;
            return 
                new string(
                    input.SkipWhile((c, i) => GetByteCount(input.Substring(0, i + 1)) <= startByte)
                        .TakeWhile((c, i) => GetByteCount(input.Substring(0, i + 1)) <= maxLength).ToArray());
        }
        private static int GetByteCount(string input)
        {
            return Encoding.UTF8.GetByteCount(input);
        }
