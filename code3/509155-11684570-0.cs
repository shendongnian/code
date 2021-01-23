    static void Main(string[] args)
    {
        Grammar g = new CSharpGrammar();
        LanguageData language = new LanguageData(g);
        Parser parser = new Parser(language);
        ParseTree parseTree = parser.Parse("", "class1.cs");
            
        var r = parseTree.Root;
    }
