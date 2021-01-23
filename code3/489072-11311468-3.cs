    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Configuration;
    
    namespace MyProjectNameSpace.Utils.WebProxy
    {
        public class CustomWebProxy : IWebProxy
        {
            public ICredentials Credentials
            {
                get
                {
                    string _proxyUserName  = ConfigurationManager.AppSettings["ProxyUserName" ] as string ?? "";
                    string _proxyPassword  = ConfigurationManager.AppSettings["ProxyPassword" ] as string ?? "";
                    string _useProxyDomain = ConfigurationManager.AppSettings["UseProxyDomain"] as string ?? "";
                    string _proxyDomain    = ConfigurationManager.AppSettings["ProxyDomain"   ] as string ?? "";
                    return String.IsNullOrEmpty(_proxyDomain)
                        ? new NetworkCredential(_proxyUserName, _proxyPassword)
                        : new NetworkCredential(_proxyUserName, _proxyPassword, _proxyDomain);
                }
                set { }
            }
            public Uri GetProxy(Uri destination)
            {
                string _proxyServer = ConfigurationManager.AppSettings["ProxyServer"] as string ?? "";
                Uri result = new Uri(_proxyServer);
                return result;
            }
            public bool IsBypassed(Uri host)
            {
                return false;
            }
        }
    }
