    static void Main(string[] args)
    {
        //We'll use ! for not, / for and, \ for or and remove whitespace
        string expr = @"!((A/B)\C\D)";
        List<Token> tokens = new List<Token>();
        StringReader reader = new StringReader(expr);
    
        //Tokenize the expression
        Token t = null;
        do
        {
            t = new Token(reader);
            tokens.Add(t);
        } while (t.type != Token.TokenType.EXPR_END);
    
        //Use a minimal version of the Shunting Yard algorithm to transform the token list to polish notation
        List<Token> polishNotation = TransformToPolishNotation(tokens);
    
        var enumerator = polishNotation.GetEnumerator();
        enumerator.MoveNext();
        BoolExpr root = Make(ref enumerator);
    
        //Request boolean values for all literal operands
        foreach (Token tok in polishNotation.Where(token => token.type == Token.TokenType.LITERAL))
        {
            Console.Write("Enter boolean value for {0}: ", tok.value);
            string line = Console.ReadLine();
            booleanValues[tok.value] = Boolean.Parse(line);
            Console.WriteLine();
        }
    
        //Eval the expression tree
        Console.WriteLine("Eval: {0}", Eval(root));
    
        Console.ReadLine();
    }
