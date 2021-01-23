    public class DelegateTokenStore : ITokenStore
    {
        public delegate IToken TokenCreator(IOAuthContext context);
        public TokenCreator RequestTokenCreator { get; set; }
        public TokenCreator AccessTokenCreator { get; set; }
    
        public IToken CreateRequestToken(IOAuthContext context)
        {
            return RequestTokenCreator(context);
        }
    
        public IToken CreateAccessToken(IOAuthContext context)
        {
            return AccessTokenCreator(context);
        }
    }
