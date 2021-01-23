    public class MyTokenStore: ITokenStore
    {
        public IToken CreateRequestToken(IOAuthContext context)
        {
            ...some code here...
        }
        public IToken CreateAccessToken(IOAuthContext context)
        {
            ...some code here...
        }
    }
