    static MethodDeclarationSyntax 
        RewriteMethodDeclaration(MethodDeclarationSyntax method, string name)
    {
        var type = Syntax.ParseTypeName("dynamic");
        var identifier = Syntax.Identifier(String.Format(" {0}", name));
        var p = Syntax.Parameter(
            new SyntaxList<AttributeListSyntax>(),
            new SyntaxTokenList(),
            type,
            identifier,
            null);
        var parameters = method.ParameterList.AddParameters(p);
        return method.WithParameterList(parameters);
    }
