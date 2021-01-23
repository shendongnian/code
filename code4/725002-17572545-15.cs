    static List<Token> TransformToPolishNotation(List<Token> infixTokenList)
    {
        Queue<Token> outputQueue = new Queue<Token>();
        Stack<Token> stack = new Stack<Token>();
    
        int index = 0;
        while (infixTokenList.Count > index)
        {
            Token t = infixTokenList[index];
    
            switch (t.type)
            {
                case Token.TokenType.LITERAL:
                    outputQueue.Enqueue(t);
                    break;
                case Token.TokenType.BINARY_OP:
                case Token.TokenType.UNARY_OP:
                case Token.TokenType.OPEN_PAREN:
                    stack.Push(t);
                    break;
                case Token.TokenType.CLOSE_PAREN:
                    while (stack.Peek().type != Token.TokenType.OPEN_PAREN)
                    {
                        outputQueue.Enqueue(stack.Pop());
                    }
                    stack.Pop();
                    if (stack.Peek().type == Token.TokenType.UNARY_OP)
                    {
                        outputQueue.Enqueue(stack.Pop());
                    }
                    break;
                default:
                    break;
            }
    
            ++index;
        }
        while (stack.Count > 0)
        {
            outputQueue.Enqueue(stack.Pop());
        }
    
        return outputQueue.Reverse().ToList();
    }
