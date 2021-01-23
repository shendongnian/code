        public static IEnumerable<int> Utf8ToCodePoints(this string s)
        {
            var utf8Bytes = Encoding.UTF8.GetBytes(s);
            byte[] utf32bytes = Encoding.Convert(Encoding.UTF8, Encoding.UTF32, utf8Bytes);
            var bytesPerCharInUtf32 = 4;
            Debug.Assert(utf32bytes.Length % bytesPerCharInUtf32 == 0);
            for (int i = 0; i < utf32bytes.Length; i+= bytesPerCharInUtf32)
            {
                yield return BitConverter.ToInt32(utf32bytes, i);
            }
        }
