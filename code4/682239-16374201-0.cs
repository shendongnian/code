    var invocationExpression =
        Syntax.InvocationExpression(
            Syntax.MemberAccessExpression(
                SyntaxKind.MemberAccessExpression,
                Syntax.IdentifierName(variableSymbol.Name),
                (SimpleNameSyntax)Syntax.ParseName(selectedMethod.Name)));
