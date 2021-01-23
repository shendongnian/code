    public class SimpleWebProxy : IWebProxy
    {
        public ICredentials Credentials { get; set; }
        public Uri GetProxy(Uri destination)
        {
            return destination;
        }
        public bool IsBypassed(Uri host)
        {
            // if return true, service will be very slow.
            return false;
        }
        private static SimpleWebProxy defaultProxy = new SimpleWebProxy();
        public static SimpleWebProxy Default
        {
            get
            {
                return defaultProxy;
            }
        }
    }
    var client = new RestClient();
    client.Proxy = SimpleWebProxy.Default;
