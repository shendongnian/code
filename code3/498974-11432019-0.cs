    profileOrgs.ForEach(o =>
    {
        // Right here -- var duplicate has scope ONLY within your query. 
        // As soon as the query is executed it leaves scope and the reference
        // pointer will be null
        var duplicate = kvkOrgs.FirstOrDefault(k => k.KvK == o.KvK || k.Title == o.Title);
        if (duplicate != null)
        {
            o.CompanyInfoOrganisation = duplicate.CompanyInfoOrganisation;
            o.ExistsInBoth = true;
            kvkOrgs.Remove(duplicate);
        }
    });
