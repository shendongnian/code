    static void Main(string[] args)
    {
        int index = 0;
        string text = "{a test entry}  {{1}{{city}{chicago}{employee}{johnsmith}{building}{5}{room}{506A}{room}{506B}{id}{1234}}{2}{{city}{losangeles}{employee}{johnsmith}{building}{1}{room}{101A}{room}{102B}{id}{1234}}}";
        
        var tokens = Tokenize(text);        
        var node = Parse(new Node(new Token() { TokenType = TokenType.Root, Value = string.Empty }), tokens, ref index);
        RaiseSubtrees(node);
        
        Console.WriteLine(node.ToString());
    }
    static List<Token> Tokenize(string text)
    {
        Stack<StringBuilder> stack = new Stack<StringBuilder>();
        List<Token> tokens = new List<Token>();
        foreach (var ch in text)
        {
            if (ch == '{')
            {
                stack.Push(new StringBuilder());
                tokens.Add(new Token(TokenType.ObjectStart, "{" ));
            }
            else if (ch == '}')
            {
                var item = stack.Pop().ToString();
                if (!string.IsNullOrEmpty(item))
                {
                    tokens.Add(new Token(TokenType.Text, item));
                }
                tokens.Add(new Token(TokenType.ObjectEnd, "}"));
            }
            else if (stack.Count != 0)
            {
                stack.Peek().Append(ch);
            }
        }
        return tokens;
    }
    static Node Parse(Node parent, List<Token> tokens, ref int index)
    {
        for (; index < tokens.Count - 1; index++)
        {
            Token current = tokens[index];
            Token next = tokens[index + 1];
            if (current.TokenType == TokenType.ObjectStart)
            {
                Node child = new Node(current);
                parent.Children.Add(child);
                index++;
                Parse(child, tokens, ref index);
            }
            else if (current.TokenType == TokenType.Entry || current.TokenType == TokenType.Text)
            {
                Node child = new Node(current);
                parent.Children.Add(child);
            }
            else if (current.TokenType == TokenType.ObjectEnd)
            {
                return parent;
            }
        }
        return parent;
    }
    static void RaiseSubtrees(Node node)
    {
        if (node.Children.Count == 1)
        {
            node.Token = node.Children.First().Token;
            node.Children.Clear();
        }
        else
        {
            foreach (Node child in node.Children)
            {
                RaiseSubtrees(child);
            }
            if (node.Children.All(c => c.Token.TokenType == TokenType.Text))
            {
                for (int i = node.Children.Count - 1; i >= 1; i-=2)
                {
                    Node keyNode = node.Children[i - 1];
                    Node valueNode = node.Children[i];
                    keyNode.Token.TokenType = TokenType.Key;
                    valueNode.Token.TokenType = TokenType.Value;
                    Node newParent = new Node(new Token(TokenType.Property, string.Empty));
                    newParent.Children.Add(keyNode);
                    newParent.Children.Add(valueNode);
                    node.Children.RemoveAt(i);
                    node.Children.RemoveAt(i - 1);
                    node.Children.Insert(i - 1, newParent);
                }
            }
        }
    }
    
    enum TokenType
    {
        Entry,
        Key,
        ObjectStart,
        ObjectEnd,
        Property,
        Root,
        Text,
        Value
    }
    class Token
    {
        public TokenType TokenType { get; set; }
        public string Value { get; set; }
        public Token()
        {
        }
        public Token(TokenType tokenType, string value)
        {
            this.TokenType = tokenType;
            this.Value = value;
        }
    }
    class Node
    {
        public Token Token { get; set; }
        public IList<Node> Children { get; set; }
        public Node(Token token)
        {
            this.Token = token;
            this.Children = new List<Node>();
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            ToString(this, builder, string.Empty);
            return builder.ToString();
        }
        public void ToString(Node parent, StringBuilder builder, string indent)
        {
            builder.Append(indent).Append(parent.Token.TokenType.ToString());
            if (parent.Token.TokenType != TokenType.Root && parent.Token.TokenType != TokenType.ObjectStart)
            {
                builder.Append(": ").Append(parent.Token.Value);
            }
            builder.Append("\n");
            foreach (var child in parent.Children)
            {
                ToString(child, builder, indent + "  ");
            }
        }
    }
