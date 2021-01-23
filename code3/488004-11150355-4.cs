    void WriteLineWithColoredLetter(string letters, char c) {
      var o = letters.IndexOf(c);
      Console.Write(letters.Substring(0, o));
      Console.ForegroundColor = ConsoleColor.Red;
      Console.Write(letters[o]);
      Console.ResetColor();
      Console.WriteLine(letters.Substring(o + 1));
    }
