    class ResourceInterceptor : IResourceInterceptor
    {
        // Public class property.
        public static string Referer { get; set; }
        ResourceResponse IResourceInterceptor.OnRequest(ResourceRequest request)
        {
            request.Referrer = Referer;
            return null;
        }
    }
    // Somewhere else...
    ResourceInterceptor.Referer = "www.google.com";
