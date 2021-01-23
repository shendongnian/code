    using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
    ...
    
        protected override SyntaxNode VisitPropertyDeclaration(PropertyDeclarationSyntax node)
    {
        var typeSyntax = node.Type;
        if (node.Identifier.ValueText == "Id")
        {
            typeSyntax = SyntaxFactory.IdentifierName("string");
        }
        var newProperty = PropertyDeclaration(
                    PredefinedType(
                        Token(SyntaxKind.LongKeyword)),
                    Identifier("Id"))
                .WithModifiers(
                    TokenList(
                        Token(SyntaxKind.PublicKeyword)))
                .WithAccessorList(
                    AccessorList(
                        List(new AccessorDeclarationSyntax[]{
                            AccessorDeclaration(
                                SyntaxKind.GetAccessorDeclaration)
                            .WithSemicolonToken(
                                Token(SyntaxKind.SemicolonToken)),
                            AccessorDeclaration(
                                SyntaxKind.SetAccessorDeclaration)
                            .WithSemicolonToken(
                                Token(SyntaxKind.SemicolonToken))})))
                .NormalizeWhitespace();
        return newProperty;
    }       
