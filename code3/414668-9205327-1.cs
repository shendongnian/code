        protected override SyntaxNode VisitPropertyDeclaration(PropertyDeclarationSyntax node)
    {
        var typeSyntax = node.Type;
        if (node.Identifier.ValueText == "Id")
        {
            typeSyntax = SyntaxFactory.IdentifierName("string");
        }
            var newProperty = SyntaxFactory.PropertyDeclaration(
                SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.LongKeyword)), SyntaxFactory.Identifier(@"Id"))
                .WithAttributeLists(
                    SyntaxFactory.SingletonList(
                        SyntaxFactory.AttributeList(
                            SyntaxFactory.SingletonSeparatedList(
                                SyntaxFactory.Attribute(SyntaxFactory.IdentifierName(@"DataMember"))
                                .WithArgumentList(
                                    SyntaxFactory.AttributeArgumentList(
                                        SyntaxFactory.SeparatedList(
                                            new[]{
                                                SyntaxFactory.AttributeArgument(
                                                    SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression))
                                                .WithNameEquals(
                                                    SyntaxFactory.NameEquals(
                                                        SyntaxFactory.IdentifierName(@"EmitDefaultValue"))),
                                                SyntaxFactory.AttributeArgument(
                                                    SyntaxFactory.LiteralExpression(
                                                        SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(@"Id")))
                                                .WithNameEquals(
                                                    SyntaxFactory.NameEquals(
                                                        SyntaxFactory.IdentifierName(@"Name"))) })))))))
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                .WithAccessorList(
                    SyntaxFactory.AccessorList(
                        SyntaxFactory.List<AccessorDeclarationSyntax>(
                            new AccessorDeclarationSyntax[]{
                                SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                                SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                            })));
        return newProperty;
    }       
