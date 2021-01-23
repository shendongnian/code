    public static Node ParseExpression(Token[] tok)
    {
        int i = 0;
        return parseExpressionBoolOr(tok, ref i);
    }
    private static Node parseExpressionBoolOr(Token[] tok, ref int i)
    {
        var left = parseExpressionBoolAnd(tok, ref i);
        while (tok[i].Type == TokenType.Or)
        {
            i++;
            var right = parseExpressionBoolAnd(tok, ref i);
            left = new BooleanNode(BooleanOperator.Or, left, right);
        }
        return left;
    }
    private static Node parseExpressionBoolAnd(Token[] tok, ref int i)
    {
        var left = parseExpressionPrimary(tok, ref i);
        while (tok[i].Type == TokenType.And)
        {
            i++;
            var right = parseExpressionPrimary(tok, ref i);
            left = new BooleanNode(BooleanOperator.And, left, right);
        }
        return left;
    }
    private static Node parseExpressionPrimary(Token[] tok, ref int i)
    {
        if (tok[i].Type == TokenType.OpenParenthesis)
        {
            i++;
            var node = parseExpressionBoolOr(tok, ref i);
            if (tok[i].Type != TokenType.CloseParenthesis)
                throw new InvalidOperationException();  // or customised parse exception
            return node;
        }
        else if (tok[i].Type == TokenType.Tag)
        {
            var node = new TagNode(tok[i].Item);
            i++;
            return node;
        }
        else
            throw new InvalidOperationException();  // or customised parse exception
    }
