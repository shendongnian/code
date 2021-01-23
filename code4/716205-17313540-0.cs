    if (compilationUnitSyntax != null)
    {
        var name = Syntax.QualifiedName(Syntax.IdentifierName("Custom"),
                                        Syntax.IdentifierName("Bar"));
        compilationUnitSyntax = compilationUnitSyntax
            .AddUsings(Syntax.UsingDirective(name).NormalizeWhitespace());
    }
