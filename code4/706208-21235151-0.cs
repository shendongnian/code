    using (var context = new PrincipalContext(ContextType.Domain, _domainName))
    {
        try
        {
            var p = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, username);
            if (p == null) throw new NullReferenceException(string.Format("UserPrincipal.FindByIdentity returned null for user: {0}, this can indicate a problem with one or more of the AD controllers", username));
            var groups = p.GetAuthorizationGroups();
            var domain = username.Substring(0, username.IndexOf(@"\", StringComparison.InvariantCultureIgnoreCase)).ToLower();
            foreach (GroupPrincipal group in groups)
            {
                if (!string.IsNullOrEmpty(group.Name))
                {
                    var domainGroup = domain + @"\" + group.Name.ToLower();
                    if (_groupsToUse.Any(x => x.Equals(domainGroup, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        // Go through each application role defined and check if the AD domain group is part of it
                        foreach (string role in roleKeys)
                        {
                            string[] roleMembers = new [] { "role1", "role2" };
                            foreach (string member in roleMembers)
                            {
                                // Check if the domain group is part of the role
                                if (member.ToLower().Contains(domainGroup))
                                {
                                    // Cache the Application Role (NOT the AD role)
                                    results.Add(role);
                                }
                            }
                        }
                    }
                }
                group.Dispose();
            }
        }
        catch (Exception ex)
        {
            throw new ProviderException("Unable to query Active Directory.", ex);
        }
    }
