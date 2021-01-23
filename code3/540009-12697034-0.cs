    public static IEnumerable<ICompletionData> DoCodeComplete(string editorText, int offset) // not the best way to put in the whole string every time
    {
      
      var doc = new ReadOnlyDocument(editorText);
      var location = doc.GetLocation(offset);
      string parsedText = editorText; // TODO: Why there are different values in test cases?
      var syntaxTree = new CSharpParser().Parse(parsedText, "program.cs");
      syntaxTree.Freeze();
      var unresolvedFile = syntaxTree.ToTypeSystem();
      var mb = new DefaultCompletionContextProvider(doc, unresolvedFile);
      IProjectContent pctx = new CSharpProjectContent();
      var refs = new List<IUnresolvedAssembly> { mscorlib.Value, systemCore.Value, systemAssembly.Value}; 
      pctx = pctx.AddAssemblyReferences(refs);
      pctx = pctx.AddOrUpdateFiles(unresolvedFile);
      var cmp = pctx.CreateCompilation();
      
      var resolver3 = unresolvedFile.GetResolver(cmp, location);
      var engine = new CSharpCompletionEngine(doc, mb, new CodeCompletionBugTests.TestFactory(resolver3), pctx, resolver3.CurrentTypeResolveContext );
      
      engine.EolMarker = Environment.NewLine;
      engine.FormattingPolicy = FormattingOptionsFactory.CreateMono();
      
      var data = engine.GetCompletionData(offset, controlSpace: false);
      return data;
    }
