    public IEnumerable<AaaUserContactInfo> getcontactinfo(long[] organizationIds)
    {
    	var organizationNames = entities.SDOrganizations
                               .Where(org => organizationIds.Contains(org.ORG_ID))
                               .Select(org=> org.Name);
    												
        var result = from userContactInfo in entities.AaaUserContactInfoes
                     join contactInfo in entities.AaaContactInfoes on userContactInfo.CONTACTINFO_ID equals contactInfo.CONTACTINFO_ID
                     where organizationNames.Contains(contactInfo.EMAILID.ToString())
                     select userContactInfo;
        return result;
    }
