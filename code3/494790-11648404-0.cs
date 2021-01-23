    var dot = ToTerm(".");
    var dash = ToTerm("-");
    var Id_simple = TerminalFactory.CreateSqlExtIdentifier(this, "id_simple"); //covers normal identifiers (abc) and quoted id's ([abc d], "abc d")
    Id.Rule = MakePlusRule(Id, dot, Id_simple) | MakePlusRule(Id, dash, Id_simple)
    
     //Covers simple identifiers like abcd, and also quoted versions: [abc d], "abc d".
        public static IdentifierTerminal CreateSqlExtIdentifier(Grammar grammar, string name) {
          var id = new IdentifierTerminal(name);
          StringLiteral term = new StringLiteral(name + "_qouted");
          term.AddStartEnd("[", "]", StringOptions.NoEscapes);
          term.AddStartEnd("\"", StringOptions.NoEscapes);
          term.SetOutputTerminal(grammar, id); //term will be added to NonGrammarTerminals automatically 
          return id;
        }
