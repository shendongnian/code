    public static class Cdn
    {
        private const string CdnRoot = "//cloudfrontdomainhere.com";
        private static bool EnableCdn
        {
            get
            {
                bool enableCdn = false;
                bool.TryParse(WebConfigurationManager.AppSettings["EnableCdn"], out enableCdn);
                return enableCdn;
            }
        }
        public static IHtmlString RenderScripts(string bundlePath)
        {
            if (EnableCdn)
            {
                string sourceUrl = CdnRoot + Scripts.Url(bundlePath);
                return new HtmlString(string.Format("<script src=\"{0}\"></script>", sourceUrl));
            }
            return Scripts.Render(bundlePath);
        }
        public static IHtmlString RenderStyles(string bundlePath)
        {
            if (EnableCdn)
            {
                string sourceUrl = CdnRoot + Styles.Url(bundlePath);
                return new HtmlString(string.Format("<link href=\"{0}\" rel=\"stylesheet\" />", sourceUrl));
            }
            return Styles.Render(bundlePath);
        }
    }
