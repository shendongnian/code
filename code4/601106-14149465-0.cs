    public IEnumerable<AaaUserContactInfo> getcontactinfo(long[] Organizationid)
    {
    	var organization = entities.SDOrganizations.FirstOrDefault(a => OrganizationIds.Contains(a.ORG_ID));
    	var ogranizationName = organization!=null ? organization.Name : null;
        var result = from uci in entities.AaaUserContactInfoes
                     join ci in entities.AaaContactInfoes on uci.CONTACTINFO_ID equals ci.CONTACTINFO_ID
                     where ci.EMAILID.ToString() == ogranizationName
                     select uci;
        return result;
    }
