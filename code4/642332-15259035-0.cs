    public class SiteContent : ISiteFormInjector
    {
        // Call our Dependency.
        ISiteForm _siteDetails;
    
        public void InjectSiteForm(ISiteForm siteDetails)
        {
             _siteDetails = siteDetails;
        }
    
        // Properties to Associate our Value.
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public string GetSiteValues()
        {
            return _siteDetails.GetSiteValues(FirstName, LastName);
        }
    }
        
