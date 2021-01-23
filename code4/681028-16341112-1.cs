    var originalClass =
        compilationUnit.DescendantNodes().OfType<ClassDeclarationSyntax>().Single();
    string originalClassName = originalClass.Identifier.ValueText;
    var properties =
        originalClass.DescendantNodes().OfType<PropertyDeclarationSyntax>();
    var generatedInterface =
        SyntaxFactory.InterfaceDeclaration('I' + originalClassName)
              .AddMembers(
                  properties.Select(
                      p =>
                      SyntaxFactory.PropertyDeclaration(p.Type, p.Identifier)
                            .AddAccessorListAccessors(
                                SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                      .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))))
                            .ToArray());
