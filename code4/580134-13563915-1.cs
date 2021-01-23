    // In namespace Your
    // ...
    public class MyProxy: IWebProxy
    {
        /// ====================================================================
        /// <summary>
        /// The credentials to submit to the proxy server for authentication.
        /// </summary>
        /// <returns>An <see cref="T:System.Net.ICredentials"/> instance that contains the 
        /// credentials that are needed to authenticate a request to the proxy server.</returns>
        /// ====================================================================
        public ICredentials Credentials
        {
            get 
            {
                // Read all values from the AppSettings
                string username = ConfigurationManager.AppSettings["ProxyUsername"].ToString();
                string password = ConfigurationManager.AppSettings["ProxyPassword"].ToString();
                string domain = ConfigurationManager.AppSettings["ProxyDomain"].ToString();
                return new NetworkCredential(username, password, domain); 
            }            
            set { }
        }
        /// ====================================================================
        /// <summary>
        /// Returns the URI of a proxy.
        /// </summary>
        /// <param name="destination">A <see cref="T:System.Uri"/> that specifies the requested 
        /// Internet resource.</param>
        /// <returns>
        /// A <see cref="T:System.Uri"/> instance that contains the URI of the proxy used to 
        /// contact <paramref name="destination"/>.
        /// </returns>
        /// ====================================================================
        public Uri GetProxy(Uri destination)
        {
            // Use the proxy server specified in AppSettings
            string proxy = ConfigurationManager.AppSettings["ProxyServer"].ToString();
            return new Uri(proxy);
        }
        /// ====================================================================
        /// <summary>
        /// Indicates that the proxy should not be used for the specified host.
        /// </summary>
        /// <param name="host">The <see cref="T:System.Uri"/> of the host to check for proxy use.</param>
        /// <returns>
        /// true if the proxy server should not be used for <paramref name="host"/>; otherwise, false.
        /// </returns>
        /// ====================================================================
        public bool IsBypassed(Uri host)
        {
            // Ignore localhost URIs
            string[] bypassUris = ConfigurationManager.AppSettings["ProxyBypass"].ToString().Split(',');
            foreach (string bypassUri in bypassUris)
            {
                if (host.AbsoluteUri.ToLower().Contains(bypassUri.Trim().ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
    }
