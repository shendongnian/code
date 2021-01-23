    var node = token.Parent;
    if (node is ExpressionSyntax)
    {
        type = semModel.GetTypeInfo((ExpressionSyntax)node).Type;
    }
    else if (node is VariableDeclaratorSyntax && ((VariableDeclaratorSyntax)node).Identifier == token)
    {
        type = (TypeSymbol)semModel.GetDeclaredSymbol((VariableDeclaratorSyntax)node);   
    }
