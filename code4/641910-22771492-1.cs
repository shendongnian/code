    public class NTLMAuthProvider : CredentialsAuthProvider
    {
        public override bool IsAuthorized(IAuthSession session, IAuthTokens tokens, Authenticate request = null)
        {
            return !string.IsNullOrWhiteSpace(session.UserName);
        }
    }
