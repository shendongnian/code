    static string BuildOctetString(SecurityIdentifier sid)
    {
        byte[] items = new byte[sid.BinaryLength];
        sid.GetBinaryForm(items, 0);
        StringBuilder sb = new StringBuilder();
        foreach (byte b in items)
        {
            sb.Append(b.ToString("X2"));
        }
        return sb.ToString();
    }
    public static bool IsDomainAdmin(string domain, string userName)
    {
        using (DirectoryEntry domainEntry = new DirectoryEntry(string.Format("LDAP://{0}", domain)))
        {
            byte[] domainSIdArray = (byte[])domainEntry.Properties["objectSid"].Value;
            SecurityIdentifier domainSId = new SecurityIdentifier(domainSIdArray, 0);
            SecurityIdentifier domainAdminsSId = new SecurityIdentifier(WellKnownSidType.AccountDomainAdminsSid, domainSId);
            using (DirectoryEntry groupEntry = new DirectoryEntry(string.Format("LDAP://<SID={0}>", BuildOctetString(domainAdminsSId))))
            {
                string adminDn = groupEntry.Properties["distinguishedname"].Value as string;
                SearchResult result = (new DirectorySearcher(domainEntry, string.Format("(&(objectCategory=user)(samAccountName={0}))", userName), new[] { "memberOf" })).FindOne();
                return result.Properties["memberOf"].Contains(adminDn);
            }
        }
    }
