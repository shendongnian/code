    private void button1_Click(object sender, EventArgs e)
    {
       List<string> userGroups = new List<string>();
       PrincipalContext LdapContext = new PrincipalContext(ContextType.Domain, domainName);
       UserPrincipal user = UserPrincipal.FindByIdentity(LdapContext, userName);
       foreach (var group in user.GetGroups())
       {
           userGroups.Add(group.Name);
       }
    }
