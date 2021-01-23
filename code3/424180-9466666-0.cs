        public static bool ValidateCredential(string domain, string userName, string password)
        {
            using (var context = new PrincipalContext(ContextType.Domain, domain))
            {
                using (var user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, userName))
                {
                    if (user == null) return false;
                    using (var group = GroupPrincipal.FindByIdentity(context, IdentityType.SamAccountName, "Domain Admins"))
                    {
                        if (group == null) return false;
                        foreach (var member in group.GetMembers())
                        {
                            if (member.Sid.Equals(user.Sid))
                            {
                                return context.ValidateCredentials(userName, password);
                            }
                        }
                    }
                }
            }
            return false;
        }
