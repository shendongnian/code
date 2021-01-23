    sealed class Token
    {
        public TokenType Type { get; private set; }
        public string Item { get; private set; }
        public Token(TokenType type, string item) { Type = type; Item = item; }
    }
