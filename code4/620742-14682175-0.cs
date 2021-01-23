       public static string SetGivenNameUser()
        {
            string givenName = string.Empty;
            string currentUser = HttpContext.Current.User.Identity.Name;
            // If the USer is logged in
            if (!string.IsNullOrWhiteSpace(currentUser))
            {
                MembershipUser user = Membership.GetUser();
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
                UserPrincipal userP = UserPrincipal.FindByIdentity(ctx, user.UserName);
                if (userP != null)
                    givenName = userP.GivenName;
            }
            return givenName;
        }
