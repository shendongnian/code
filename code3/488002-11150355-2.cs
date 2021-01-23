    void WriteLineWithColoredLetter(string letters, char c) {
      var o = letters.IndexOf(c);
      Console.Write(letters.Substring(0, o));
      var oldColor = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.Red;
      Console.Write(letters[o]);
      Console.ForegroundColor = oldColor;
      Console.WriteLine(letters.Substring(o + 1));
    }
