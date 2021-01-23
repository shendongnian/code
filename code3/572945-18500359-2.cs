    public class BundleHelper
    {
        public static readonly string StyleTagFormat = "<link href=\"{0}\" rel=\"stylesheet\"/>";
        public static readonly string ScriptTagFormat = "<script src=\"{0}\"></script>"
        /// <summary>
        /// Customised script bundle rendering method with CDN support if optimizations and CDN enabled.
        /// </summary>
        public static IHtmlString RenderScriptFormat(string tagFormat, string path)
        {
            if (AppSettings.Bundling.EnableCdn && Scripts.Url(path).ToString().StartsWith("/"))
            {
                tagFormat = tagFormat.Replace(" src=\"{0}\"", String.Format(" src=\"{0}{{0}}\"", AppSettings.Bundling.BundlesCDNPrefixUrl));
            }
            return Scripts.RenderFormat(tagFormat, path);
        }
        /// <summary>
        /// Customised styles bundle rendering method with CDN support if optimizations and CDN enabled.
        /// </summary>
        public static IHtmlString RenderStyleFormat(string tagFormat, string path)
        {
            if (AppSettings.Bundling.EnableCdn && Styles.Url(path).ToString().StartsWith("/"))
            {
                tagFormat = tagFormat.Replace(" href=\"{0}\"", String.Format(" href=\"{0}{{0}}\"", AppSettings.Bundling.BundlesCDNPrefixUrl));
            }
            return Styles.RenderFormat(tagFormat, path);
        }
    }
