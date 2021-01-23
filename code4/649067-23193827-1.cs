    public partial class Site : System.Web.UI.MasterPage
    {
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string SiteName { get; set; }
        public SiteSettings siteSettings { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            siteSettings = SettingsFactory<SiteSettings>.Get();
            MetaDescription = siteSettings.SearchMetaDescription;
            MetaKeywords = siteSettings.SearchMetaKeywords;
            SiteName = siteSettings.SiteName;
        }
    }
