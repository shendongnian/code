    public class AspNetSiteLocator : ISiteLocator
    {
        private readonly ISiteRepository siteRepository;
        public AspNetSiteLocator(ISiteRepository siteRepository)
        {
            this.siteRepository = siteRepository;
        }
        Site ISiteLocator.GetCurrentSite()
        {
            return this.siteRepository.GetById(CurrentHostName);
        }
        private static string CurrentHostName
        {
            get
            {
               return HttpContext.Current.Request
                   .ServerVariables["SERVER_NAME"];
            }
        }
    }
