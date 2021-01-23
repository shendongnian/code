    var o = letters.IndexOf('o');
    Console.Write(letters.Substring(0, o));
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(letters[o]);
    Console.ResetColor();
    Console.WriteLine(letters.Substring(o + 1));
