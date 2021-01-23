    string input = ...
    for (var i = 0; i < input.Length; i += char.IsSurrogatePair(input, i) ? 2 : 1)
    {
        var codepoint = char.ConvertToUtf32(input, i);
        Console.WriteLine("U+{0:x4}", codepoint);
    }
