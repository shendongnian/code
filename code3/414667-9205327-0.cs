        protected override SyntaxNode VisitPropertyDeclaration(PropertyDeclarationSyntax node)
    {
        var typeSyntax = node.Type;
        if (node.Identifier.ValueText == "Id")
        {
            typeSyntax = Syntax.IdentifierName("string");
        }
        var newProperty = Syntax.PropertyDeclaration(
            attributes: Syntax.List(
                Syntax.AttributeDeclaration(
                    attributes: Syntax.SeparatedList(
                        Syntax.Attribute(
                            name: Syntax.ParseName("DataMember"),
                            argumentListOpt: Syntax.AttributeArgumentList(
                                arguments:Syntax.SeparatedList(new[]
                                    {
                                        Syntax.AttributeArgument(
                                            nameEqualsOpt: Syntax.NameEquals(
                                                Syntax.Identifier("EmitDefaultValue")),
                                            expression: Syntax.LiteralExpression(SyntaxKind.FalseLiteralExpression)),
                                        Syntax.AttributeArgument(
                                            nameEqualsOpt: Syntax.NameEquals(
                                                Syntax.Identifier("Name")),
                                            expression: Syntax.LiteralExpression(
                                                SyntaxKind.StringLiteralExpression,
                                                Syntax.ParseToken("\"" + node.Identifier + "\""))),
                                    }, Enumerable.Repeat(Syntax.Token(SyntaxKind.CommaToken), 1))))))),
            modifiers: Syntax.TokenList(Syntax.Token(SyntaxKind.PublicKeyword)),
            type: typeSyntax,
            identifier: node.Identifier,
            accessorList: Syntax.AccessorList(
                accessors: Syntax.List(
                    Syntax.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration, 
                    semicolonTokenOpt: Syntax.Token(SyntaxKind.SemicolonToken)),
                    Syntax.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration,
                    semicolonTokenOpt: Syntax.Token(SyntaxKind.SemicolonToken))
                    )
                )
            );
        return newProperty;
    }       
