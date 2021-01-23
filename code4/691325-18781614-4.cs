        public static void Main()
        {
            var unicodeEncoding = new UnicodeEncoding(!BitConverter.IsLittleEndian, false);
            Console.InputEncoding = unicodeEncoding;
            Console.OutputEncoding = unicodeEncoding;
            var sb = new StringBuilder();
            for (var codePoint = 0; codePoint < 0x10ffff; codePoint++)
            {
                var isSurrogateCodePoint =
                   codePoint <= UInt16.MaxValue 
                   && (  char.IsLowSurrogate((char) codePoint) 
                      || char.IsHighSurrogate((char) codePoint)
                      );
                if (isSurrogateCodePoint)
                    continue;
                var codePointString = char.ConvertFromUtf32(codePoint);
                if (Regex.IsMatch(codePointString, @"\d"))
                    sb.AppendFormat("{0} ", codePointString);
            }
            Console.WriteLine(sb.ToString());
            Console.ReadKey();
        }
