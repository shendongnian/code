    public class BundleHelper
    {
        // taken from System.Web.Optimization.Styles._defaultTagFormat private variable
        public static readonly string StyleTagFormat = "<link href=\"{0}\" rel=\"stylesheet\"/>"; 
        // taken from System.Web.Optimization.Scripts._defaultTagFormat private variable
        public static readonly string ScriptTagFormat = "<script src=\"{0}\"></script>"
        /// <summary>
        /// Customised script bundle rendering method with CDN support if optimizations and CDN enabled.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IHtmlString RenderScriptFormat(string tagFormat, string path)
        {
            if (BundleTable.EnableOptimizations && AppSettings.Bundling.EnableCdn)
            {
                tagFormat = tagFormat.Replace(" src=\"/", String.Format(" src=\"{0}/", AppSettings.Bundling.BundlesCDNPrefixUrl));
            }
            return Scripts.RenderFormat(tagFormat, path);
        }
        /// <summary>
        /// Customised styles bundle rendering method with CDN support if optimizations and CDN enabled.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IHtmlString RenderStyleFormat(string tagFormat, string path)
        {
            if (BundleTable.EnableOptimizations && AppSettings.Bundling.EnableCdn)
            {
                tagFormat = tagFormat.Replace(" href=\"/", String.Format(" href=\"{0}/", AppSettings.Bundling.BundlesCDNPrefixUrl));
            }
            return Styles.RenderFormat(tagFormat, path);
        }
    }
