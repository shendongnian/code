    static void Main(string[] args) {
      string l_input1 = "match \"text\" with \r\n even \"quotes\"";
      string l_input2 = "unmatch \"text\" with \r\n uneven quotes\"";
      string l_pattern = @"^(?>([^""]*?(?<QUOTED_TEXT>(?<QUOTE>"")[^""]*(?<-QUOTE>"")?))*)$(?(QUOTE)(?!))";
      Match l_match1 = Regex.Match( l_input1, l_pattern );
      Match l_match2 = Regex.Match( l_input2, l_pattern );
      Console.WriteLine( l_match1.Success );
      foreach ( Capture l_quotedText in l_match1.Groups["QUOTED_TEXT"].Captures ) {
        Console.WriteLine( l_quotedText.Value );
      }
      Console.WriteLine( l_match2.Success );
      Console.ReadKey( true );
    }
  }
