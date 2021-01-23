    var syntaxTree = SyntaxTree.ParseCompilationUnit(code);
    
    var semanticModel = Compilation.Create("compilation")
        .AddSyntaxTrees(syntaxTree)
        .AddReferences(new AssemblyFileReference(typeof(object).Assembly.Location))
        .GetSemanticModel(syntaxTree);
    
    var baz = syntaxTree.Root
        .DescendentNodes()
        .OfType<ClassDeclarationSyntax>()
        .Single(m => m.Identifier.ValueText == "C1")
        .ChildNodes()
        .OfType<MethodDeclarationSyntax>()
        .Single(m => m.Identifier.ValueText == "Baz");
    
    var bazSymbol = semanticModel.GetDeclaredSymbol(baz);
    
    var invocations = syntaxTree.Root
        .DescendentNodes()
        .OfType<InvocationExpressionSyntax>();
    
    var bazInvocations = invocations
        .Where(i => semanticModel.GetSemanticInfo(i).Symbol == bazSymbol);
