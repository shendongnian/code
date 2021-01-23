    public class ActiveDirectoryUserValidator : IActiveDirectoryUserValidator
    {
        public void Validate(string username, string clearTextPassword, string domain)
        {
            using (var principalContext = new PrincipalContext(ContextType.Domain, domain))
            {
                // validate the credentials
                bool isValid = principalContext.ValidateCredentials(username, clearTextPassword);
                if (!isValid)
                    throw new Exception("Invalid username or password.");
            }
        }
    }
