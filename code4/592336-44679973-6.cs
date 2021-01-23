        public static IEnumerable<int> Utf8ToCodePoints(this string s)
        {
            var utf32Bytes = Encoding.UTF32.GetBytes(s);
            var bytesPerCharInUtf32 = 4;
            Debug.Assert(utf32bytes.Length % bytesPerCharInUtf32 == 0);
            for (int i = 0; i < utf32bytes.Length; i+= bytesPerCharInUtf32)
            {
                yield return BitConverter.ToInt32(utf32bytes, i);
            }
        }
