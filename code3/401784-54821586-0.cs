    namespace YourProxyNameSpace
    {
      public class YourProxyClass: IWebProxy
      {
            public Uri GetProxy(Uri destination)
            {
                string proxy = ConfigurationManager.AppSettings["proxyaddress"];
                return new Uri(proxy);
            }
    
            public bool IsBypassed(Uri host)
            {
                return false;
            }
    
            public ICredentials Credentials
            {
                get
                {
                    string username = ConfigurationManager.AppSettings["username"];
                    string password = ConfigurationManager.AppSettings["password"];
                    return new NetworkCredential(username, password);
                }
                set { }
            }
        }
    }
