    public class SiteSettings {
        public SiteSettings(IUnitOfWorkFactory uowFactory) { .... }
        ....
    }
    public class INeedToAccessSiteSettings
    {
        public INeedToAccessSiteSettings(SiteSettings siteSettings) { .... }
    }
    kenrel.Bind<SiteSettings>().ToSelf().InSingletonScope();
    
