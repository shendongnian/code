    namespace DotNetOpenAuth_Library
    {
        // make class public
        public class EmbeddedResourceUrlService : IEmbeddedResourceRetrieval
        {
            private static string pathFormat = "{0}/Resource/GetWebResourceUrl?    assemblyName=    {1}&typeName={2}&resourceName={3}";
            //private static string pathFormat = "{0}/Resource/GetWebResourceUrl";
            public Uri GetWebResourceUrl(Type someTypeInResourceAssembly, string     manifestResourceName)
        {
            if (manifestResourceName.Contains("http"))
            {
                return new Uri(manifestResourceName);
            }
            else
            {
                var assembly = someTypeInResourceAssembly.Assembly;
                // HACK
                string completeUrl = HttpContext.Current.Request.Url.ToString();
                string host = completeUrl.Substring(0,
                    completeUrl.IndexOf(HttpContext.Current.Request.Url.AbsolutePath));
                var path = string.Format(pathFormat,
                            host,
                            HttpUtility.UrlEncode(assembly.FullName),
                            HttpUtility.UrlEncode(someTypeInResourceAssembly.ToString()),
                            HttpUtility.UrlEncode(manifestResourceName));
                return new Uri(path);
            }
        }
    }
