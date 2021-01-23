    [WebGet]
    public IEnumerable<OAuthMembership> GetOAuthUser(string provider, 
                                                     string providerUserId)
    {
        providerUserId = Uri.UnescapeDataString(providerUserId);
        using (var db = new WebsiteMembershipEntities())
        {
            return db.OAuthMemberships.Where(o=>o.Provider == provider && 
                                                o.ProviderUserId == providerUserId)
                     .ToList();
        }
    }
