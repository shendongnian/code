    public static void Main()
    {
        var unicodeEncoding = new UnicodeEncoding(!BitConverter.IsLittleEndian, false);
        Console.InputEncoding = unicodeEncoding;
        Console.OutputEncoding = unicodeEncoding;
        var sb = new StringBuilder();
        for (var codePoint = 0; codePoint <= 0x10ffff; codePoint++)
        {
            var isSurrogateCodePoint = codePoint <= UInt16.MaxValue 
                   && (  char.IsLowSurrogate((char) codePoint) 
                      || char.IsHighSurrogate((char) codePoint)
                      );
            if (isSurrogateCodePoint)
                continue;
            var codePointString = char.ConvertFromUtf32(codePoint);
            foreach (var category in new []{
	        UnicodeCategory.DecimalDigitNumber,
                UnicodeCategory.LetterNumber,
                UnicodeCategory.OtherNumber})
            {
	        sb.AppendLine($"{category}");
                foreach (var ch in charInfo[category])
	        {
                    sb.Append(ch);
                }
                sb.AppendLine();
            }
        }
        Console.WriteLine(sb.ToString());
        Console.ReadKey();
    }
