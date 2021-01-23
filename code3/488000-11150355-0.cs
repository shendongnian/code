    var o = letters.IndexOf('o');
    Console.Write(letters.Substring(0, o));
    var oldColor = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(letters[o];
    Console.ForegroundColor = oldColor;
    Console.WriteLine(letters.Substring(o + 1));
