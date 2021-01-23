    public static bool MatchType(string str, Type type) {
        var queue = new Queue<Token>(Tokenize(str));
        return MatchRecursive(queue, type) && (queue.Count == 0);
    }
    private static bool MatchRecursive(Queue<Token> tokens, Type type) {
        string baseName;
        if (!ReadToken(tokens, TokenType.Identifier, out baseName)) return false;
        var ranks = new List<int>();
        while (type.IsArray) {
            ranks.Add(type.GetArrayRank());
            type = type.GetElementType();
        }
        if (type.IsGenericType) {
            if (!type.Name.StartsWith(baseName+"`") || !DropToken(tokens, TokenType.Tick)) return false;
            string numStr;
            int num;
            if (!ReadToken(tokens, TokenType.Number, out numStr)
            ||  !int.TryParse(numStr, out num)
            ||  !DropToken(tokens, TokenType.OpenBraket)) return false;
            var genParams = type.GetGenericArguments();
            if (genParams.Length != num) return false;
            for (var i = 0 ; i < num ; i++) {
                if (i != 0 && !DropToken(tokens, TokenType.Comma)) return false;
                if (!MatchRecursive(tokens, genParams[i])) return false;
            }
            if (!DropToken(tokens, TokenType.CloseBraket)) return false;
        }
        foreach (var rank in ranks) {
            if (!DropToken(tokens, TokenType.OpenBraket)) return false;
            for (var i = 0 ; i != rank-1 ; i++) {
                if (!DropToken(tokens, TokenType.Comma)) return false;
            }
            if (!DropToken(tokens, TokenType.CloseBraket)) return false;
        }
        return type.IsGenericType || Aliases.Contains(new Tuple<string, Type>(baseName, type)) || type.Name == baseName;
    }
    private static readonly ISet<Tuple<string,Type>> Aliases = new HashSet<Tuple<string, Type>> {
        new Tuple<string, Type>("bool", typeof(bool)),
        new Tuple<string, Type>("byte", typeof(byte)),
        new Tuple<string, Type>("sbyte", typeof(sbyte)),
        new Tuple<string, Type>("char", typeof(char)),
        new Tuple<string, Type>("string", typeof(string)),
        new Tuple<string, Type>("short", typeof(short)),
        new Tuple<string, Type>("ushort", typeof(ushort)),
        new Tuple<string, Type>("int", typeof(int)),
        new Tuple<string, Type>("uint", typeof(uint)),
        new Tuple<string, Type>("long", typeof(long)),
        new Tuple<string, Type>("ulong", typeof(ulong)),
        new Tuple<string, Type>("float", typeof(float)),
        new Tuple<string, Type>("double", typeof(double)),
        new Tuple<string, Type>("decimal", typeof(decimal)),
        new Tuple<string, Type>("void", typeof(void)),
        new Tuple<string, Type>("object", typeof(object))
    };
    private enum TokenType {
        OpenBraket,
        CloseBraket,
        Comma,
        Tick,
        Identifier,
        Number
    }
    private class Token {
        public TokenType Type { get; private set; }
        public string Text { get; private set; }
        public Token(TokenType type, string text) {
            Type = type;
            Text = text;
        }
        public override string ToString() {
            return string.Format("{0}:{1}", Enum.GetName(typeof(TokenType), Type), Text);
        }
    }
    private static bool DropToken(Queue<Token> tokens, TokenType expected) {
        return (tokens.Count != 0) && (tokens.Dequeue().Type == expected);
    }
    private static bool ReadToken(Queue<Token> tokens, TokenType expected, out string text) {
        var res = (tokens.Count != 0) && (tokens.Peek().Type == expected);
        text = res ? tokens.Dequeue().Text : null;
        return res;
    }
    private static IEnumerable<Token> Tokenize(IEnumerable<char> str) {
        var res = new List<Token>();
        var text = new StringBuilder();
        foreach (var c in str) {
            var pos = "[],`".IndexOf(c);
            if ((pos != -1 || char.IsWhiteSpace(c)) && text.Length != 0) {
                res.Add(new Token(
                    char.IsDigit(text[0]) ? TokenType.Number : TokenType.Identifier
                ,   text.ToString())
                );
                text.Clear();
            }
            if (pos != -1) {
                res.Add(new Token((TokenType)pos, c.ToString(CultureInfo.InvariantCulture)));
            } else if (!char.IsWhiteSpace(c)) {
                text.Append(c);
            }
        }
        if (text.Length != 0) {
            res.Add(new Token(
                char.IsDigit(text[0]) ? TokenType.Number : TokenType.Identifier
            ,   text.ToString())
            );
        }
        return res;
    }
