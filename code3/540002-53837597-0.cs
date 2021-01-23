    using System.Net.Http;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    
    public class MyController : ApiController
    {
    
        // use this HttpClient instance when making calls that need cert errors suppressed
        private static readonly HttpClient httpClient;
    
        static MyController()
        {
            // create a separate handler for use in this controller
            var handler = new HttpClientHandler();
    
            // add a custom certificate validation callback to the handler
            handler.ServerCertificateCustomValidationCallback = ((sender, cert, chain, errors) => ValidateCert(sender, cert, chain, errors));
    
            // create an HttpClient that will use the handler
            httpClient = new HttpClient(handler);
        }
    
        protected static ValidateCert(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors errors)
        {
    
            // set a list of servers for which cert validation errors will be ignored
            var overrideCerts = new string[]
            {
                "myproblemserver",
                "someotherserver",
                "localhost"
            };
    
            // if the server is in the override list, then ignore any validation errors
            var serverName = cert.Subject.ToLower();
            if (overrideCerts.Any(overrideName => serverName.Contains(overrideName))) return true;
    
            // otherwise use the standard validation results
            return errors == SslPolicyErrors.None;
        }
    
    }
