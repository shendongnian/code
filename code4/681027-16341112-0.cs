    var originalClass =
        compilationUnit.DescendantNodes().OfType<ClassDeclarationSyntax>().Single();
    string originalClassName = originalClass.Identifier.ValueText;
    var properties =
        originalClass.DescendantNodes().OfType<PropertyDeclarationSyntax>();
    var generatedInterface =
        Syntax.InterfaceDeclaration('I' + originalClassName)
              .AddMembers(
                  properties.Select(
                      p =>
                      Syntax.PropertyDeclaration(p.Type, p.Identifier)
                            .AddAccessorListAccessors(
                                Syntax.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                      .WithSemicolonToken(Syntax.Token(SyntaxKind.SemicolonToken))))
                            .ToArray());
