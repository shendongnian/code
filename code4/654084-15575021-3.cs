    public bool ValidateUser(string userName, string password) {
        using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "[active directory domain here]"))
        {
            return pc.ValidateCredentials(userName, password);
        }
    }
