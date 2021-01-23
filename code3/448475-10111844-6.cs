    public class ImpersonateServices
    {
        public ImpersonateServices(String userName, String domain, String password)
        {
            this.UserName = userName;
            this.Domain = domain;
            this.Password = password;
        }
        public string UserName { get; private set; }
        public string Domain { get; private set; }
        public string Password { get; private set; }
        public void Execute(Action privilegedAction)
        {
            CodeImpersonate codeImpersonate = null;
            try
            {
                codeImpersonate = new CodeImpersonate();
                var isLoggedIn = codeImpersonate.ImpersonateValidUser(this.UserName, this.Domain, this.Password);
                if (isLoggedIn){
                    privilegedAction();
                }
                else
                    throw new InvalidOperationException("Login failed for office user.");
            }
            finally
            {
                if (codeImpersonate != null)
                    codeImpersonate.UndoImpersonation();
                codeImpersonate = null;
            }
        }
    }
