    class Program
    {
        public enum TokenName { NEWLINE, WHITESPACE, TABSPACE, A, B, C};
        public class Token
        {
            public TokenName TokenName { get; set; }
            public string TokenValue { get; set; }
            public Token Previous
            {
                get;
                set;
            }
            public Token Next
            {
                get;
                set;
            }
            public Token(TokenName name, string value)
            {
                TokenName = name;
                TokenValue = value;
            }
        }
        
        static void Main(string[] args)
        {
            int count = 0, j=0;
            Token tkn = null;
            List<Token> tokenList = new List<Token>();
            tokenList.Add(new Token(TokenName.NEWLINE, "7"));
            tokenList.Add(new Token(TokenName.A, "1"));
            tokenList.Add(new Token(TokenName.B, "2"));
            tokenList.Add(new Token(TokenName.TABSPACE, "5"));
            tokenList.Add(new Token(TokenName.C, "3"));
            tokenList.Add(new Token(TokenName.WHITESPACE, "8"));
            foreach (Token tken in tokenList)
            {
                Console.WriteLine(tken.TokenName.ToString() +" "+  tken.TokenValue.ToString());
            }
            for(int i=0; i<tokenList.Count; i++)
            {
                switch (tokenList[i].TokenName)
                {
                    case TokenName.NEWLINE:
                    case TokenName.TABSPACE:
                    case TokenName.WHITESPACE: break;
                    default:
                        count++;
                        if (tkn == null)
                        {
                            tkn = tokenList[i];
                            j=i;                            
                        }
                        if (count > 1)
                        {
                            tokenList[i].Previous = tkn;
                            tkn.Next = tokenList[i];
                            tkn = tokenList[i];
                            count++;
                        }
                        break;                                        
                }                          
            }
            tkn = tokenList[j];
            do
            {
                Console.WriteLine(tkn.TokenName.ToString() +" "+ tkn.TokenValue.ToString());
                tkn = tkn.Next;                
            }
            while (tkn != null);
            Console.ReadLine();
        }
    }
