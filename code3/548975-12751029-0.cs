    Syntax.Argument(
        Syntax.NameColon(param.Identifier.ValueText),
        default(SyntaxToken),
        Syntax.DefaultExpression(param.Type))
    // Produces output like:
    //    baseUri: default(string)
