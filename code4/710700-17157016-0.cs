    var formattedUnit = (SyntaxNode)compUnit.Format(
        new FormattingOptions(false, 4, 4)).GetFormattedRoot();
    formattedUnit = formattedUnit.ReplaceNodes(
        formattedUnit.DescendantNodes()
                     .OfType<PropertyDeclarationSyntax>()
                     .SelectMany(p => p.AttributeLists),
        (_, node) => node.WithTrailingTrivia(Syntax.Whitespace("\n")));
    string result = formattedUnit.GetText().ToString();
