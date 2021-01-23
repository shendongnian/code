    private static Regex CharactersToEscape = new Regex(@"['""]"); // Extend the character set as requird
    public string EscapeForPowerShell(string input) {
      // $& is the characters that were matched
      return CharactersToEscape.Replace(input, "`$&");
    }
