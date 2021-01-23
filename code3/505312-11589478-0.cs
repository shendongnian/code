    public enum TokenType
    {
        Unknown = 0,
        Tx = 1,
        Rx = 2
    }
    public class Token
    {
        public TokenType TokenType { get; set; }
        public IEnumerable<string> Values { get; set; }
    }
    public class TokenParser
    {
        public Token ParseToken(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) throw new ArgumentNullException("input");
            var token = new Token { TokenType = TokenType.Unknown };
            input = input.ToUpperInvariant();
            if (input.Contains("[TX]"))
            {
                token.TokenType = TokenType.Tx;
            }
            if (input.Contains("[RX]"))
            {
                token.TokenType = TokenType.Rx;
            }
            input = input.Substring(input.LastIndexOf("]", System.StringComparison.Ordinal) + 1);
            token.Values = input.Trim().Split(Convert.ToChar(" "));
            return token;
        }
    }
