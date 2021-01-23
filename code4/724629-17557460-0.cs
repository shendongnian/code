    var customerDetails = entities.AccountDefinitions
        .Where(a => a.ORG_ID == id)
        .Select(cd => new CustomerDetails
        {
            AD = cd,
            SD = cd.SDOrganization,
            AA = cd.SDOrganization.AaaPostalAddresses,
            SN = cd.SiteDefinitions
       })
       .SingleOrDefault();
    if (customerDetails != null)
    {
        customerDetails.Ar = customerDetails.SN...
    }
    return customerDetails;
