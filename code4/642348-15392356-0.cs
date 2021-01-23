    public class BrowserCapabilities
    {
        public static HttpBrowserCapabilities 
            GetHttpBrowserCapabilities(NameValueCollection headers, string userAgent)
        {
            var factory = new BrowserCapabilitiesFactory();
            var browserCaps = new HttpBrowserCapabilities();
            var hashtable = new Hashtable(180, StringComparer.OrdinalIgnoreCase);
            hashtable[string.Empty] = userAgent;
            browserCaps.Capabilities = hashtable;
            factory.ConfigureBrowserCapabilities(headers, browserCaps);
            factory.ConfigureCustomCapabilities(headers, browserCaps);
            return browserCaps;
        }
    }
