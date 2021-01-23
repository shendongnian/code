    public IEnumerable<AaaUserContactInfo> getcontactinfo(long[] organizationIds)
    {
    	var organizationNames = entities.SDOrganizations
                               .Where(org => organizationIds.Contains(org.ORG_ID))
                               .Select(org=> org.Name);
    				
								
        var result = from userContactInfo in entities.AaaUserContactInfoes
                     join contactInfo in entities.AaaContactInfoes on userContactInfo.CONTACTINFO_ID equals contactInfo.CONTACTINFO_ID
                     
                     //check if EMAILID string has at least one organizationName as substring
                     where organizationNames.Any(orgName => contactInfo.EMAILID.ToString().Contains(orgName))
                     select userContactInfo;
        return result;
    }
