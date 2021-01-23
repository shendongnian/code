    public class BundleHelper
    {
        public static readonly string StyleTagFormat = "<link href=\"{0}\" rel=\"stylesheet\"/>";
        public static readonly string ScriptTagFormat = "<script src=\"{0}\"></script>"
        /// <summary>
        /// Customised script bundle rendering method with CDN support if optimizations and CDN enabled.
        /// </summary>
        public static IHtmlString RenderScriptFormat(string tagFormat, string path)
        {
            // Check for absolute url to ensure the standard framework support for CDN bundles, with a CdnPath still works.
            if (AppSettings.Bundling.EnableCdn && !UriHelper.IsAbsoluteUrl(Scripts.Url(path).ToString()))
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
            // Check for absolute url to ensure the standard framework support for CDN bundles, with a CdnPath still works.
            if (AppSettings.Bundling.EnableCdn && !UriHelper.IsAbsoluteUrl(Styles.Url(path).ToString()))
            {
                tagFormat = tagFormat.Replace(" href=\"{0}\"", String.Format(" href=\"{0}{{0}}\"", AppSettings.Bundling.BundlesCDNPrefixUrl));
            }
            return Styles.RenderFormat(tagFormat, path);
        }
    }
    public class UriHelper
    {
        /// <summary>
        /// Determines whether a url is absolute or not.
        /// </summary>
        /// <param name="url">Url string  to test.</param>
        /// <returns>true/false.</returns>
        /// <remarks>
        /// Examples:
        ///     ?IsAbsoluteUrl("hello")
        ///     false
        ///     ?IsAbsoluteUrl("/hello")
        ///     false
        ///     ?IsAbsoluteUrl("ftp//hello")
        ///     false
        ///     ?IsAbsoluteUrl("//hello")
        ///     true
        ///     ?IsAbsoluteUrl("ftp://hello")
        ///     true
        ///     ?IsAbsoluteUrl("http://hello")
        ///     true
        ///     ?IsAbsoluteUrl("https://hello")
        ///     true
        /// </remarks>
        public static bool IsAbsoluteUrl(string url)
        {
            Uri result;
            return Uri.TryCreate(url, UriKind.Absolute, out result);
        }
    }
