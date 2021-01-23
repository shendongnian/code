        var enc = Encoding.GetEncoding("Windows-1251");
        char myCharacter = 'д'; // Cyrillic 'd'
        byte code = enc.GetBytes(new[] { myCharacter, })[0];
        Console.WriteLine(code.ToString());      // "228" (decimal)
        Console.WriteLine(code.ToString("X2"));  // "E4" (hex)
