    public Guid GetUserId(string username, bool userIsOnline) {
        using(PrincipalContext pc = new PrincipalContext(ContextType.Domain, "[active directory domain here]")) {
            var user = UserPrincipal.FindByIdentity(pc, IdentityType.SamAccountName, username);
            if(user != null)
                return user.Guid.Value;
            else
                return null;
        }
    }
