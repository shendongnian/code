     string original = "a b c";
     Regex[] expressions = new Regex[] {
          // @ sign used to signify a literal string
          new Regex(@"(\ba\b)"), // \b represents a word boundary, between a word and a space
          new Regex(@"(\bb\b)"),
     };
     string[] replacements = new string[] {
          "ab",
          "c"
     };
     for(int i = 0; i < expressions.Length; i++)
          original = expressions[i].Replace(original, replacements[i]);
