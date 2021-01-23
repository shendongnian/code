      Regex r = new Regex(@"
          \b[A-Z][a-z]+\b
          (?!
            (?>
              [^{}]+
              |
              { (?<Open>)
              |
              } (?<-Open>)
            )*
            $
            (?(Open)(?!))
          )", RegexOptions.ExplicitCapture | RegexOptions.IgnorePatternWhitespace);
      string s = "testa Testb { Test1 Testc testd 1Test } Teste { Testf {testg Testh} testi } Testj";
      foreach (Match m in r.Matches(s))
      {
        Console.WriteLine(m.Value);
      }
