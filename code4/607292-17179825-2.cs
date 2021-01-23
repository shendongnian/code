    using ServiceStack.ServiceInterface.Auth;
    
    public class CustomAuthRepository : InMemoryAuthRepository
    {
        public override bool TryAuthenticate(string userName, string password, out UserAuth userAuth)
        {
            userAuth = null;
    
            if (userName == "MyUser" && password == "123")
            {
                userAuth = new UserAuth();
                return true;
            }
    
            return false;
        }
    }
