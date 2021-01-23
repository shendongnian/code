    var charInfo = Enumerable.Range(0, 0x110000)
                             .Where(x => x < 0x00d800 || x > 0x00dfff)
                             .Select(char.ConvertFromUtf32)
                             .GroupBy(s => char.GetUnicodeCategory(s, 0))
                             .ToDictionary(g => g.Key);
    
    foreach (var ch in charInfo[UnicodeCategory.LowercaseLetter])
    {
        Console.Write(ch);
    }
