    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, dc);
    UserPrincipal u = UserPrincipal.FindByIdentity(ctx, user);
    string firstname = u.GivenName;
    string lastname = u.Surname;
    string email = u.EmailAddress;
    string telephone = u.VoiceTelephoneNumber;
    string company = String.Empty;
    ...//how I can get company and other properties?
    if (userPrincipal.GetUnderlyingObjectType() == typeof(DirectoryEntry))
    {
        // Transition to directory entry to get other properties
        using (var entry = (DirectoryEntry)userPrincipal.GetUnderlyingObject())
        {
            if (entry.Properties["company"] != null)
                company = entry.Properties["company"].Value.ToString();
        }
    }
