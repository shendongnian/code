        public interface ILoginContext
        {
            //Expose whatever properties you need to describe the login process, such as parameters and results
            void Login(Credentials credentials);
        }
        public sealed class AuthManager
        {
            public ILoginContext GetLoginContext()
            {
                return new LoginContext(this);
            }
            
            private sealed class LoginContext : ILoginContext
            {
                public LoginContext(AuthManager manager)
                {
                    //We pass in manager so that the context can use whatever it needs from the manager to do its job    
                }
                //...
            }
        }
