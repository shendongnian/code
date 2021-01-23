    var mailList = new List<MailAddress>();
    var adDomain = "yourdomain";
    var adGroup = "yourgroup";
    
    using (var context = new PrincipalContext(ContextType.Domain, adDomain))
    {
        using (var groupContext = GroupPrincipal.FindByIdentity(context, adGroup))
        {
            mailList = groupContext.GetMembers(true)
                                   .Cast<UserPrincipal>()
                                   .Where(x => !string.IsNullOrEmpty(x.EmailAddress) && !string.IsNullOrEmpty(x.DisplayName))
                                   .Select(x => new MailAddress(x.EmailAddress, x.DisplayName))
                                   .ToList();
        }
        
    }
    
    return mailList;
