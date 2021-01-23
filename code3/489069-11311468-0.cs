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
    
                    string _proxyUserName = ConfigurationManager.AppSettings["ProxyUserName"] == null ?
                            string.Empty : ConfigurationManager.AppSettings["ProxyUserName"].ToString();
    
                    string _proxyPassword = ConfigurationManager.AppSettings["ProxyPassword"] == null ?
                            string.Empty : ConfigurationManager.AppSettings["ProxyPassword"].ToString();
    
                    string _useProxyDomain = ConfigurationManager.AppSettings["UseProxyDomain"] == null ?
                            string.Empty : ConfigurationManager.AppSettings["UseProxyDomain"].ToString();
    
                    string _proxyDomain = ConfigurationManager.AppSettings["ProxyDomain"] == null ?
                            string.Empty : ConfigurationManager.AppSettings["ProxyDomain"].ToString();
    
    
                    if (_proxyDomain == string.Empty)
                    {
                        return new NetworkCredential(_proxyUserName, _proxyPassword);
                    }
                    else
                    {
                        return new NetworkCredential(_proxyUserName, _proxyPassword, _proxyDomain);
                    }
    
                }
    
                set { }
    
            }
    
    
    
            public Uri GetProxy(Uri destination)
            {
    
                string _proxyServer = ConfigurationManager.AppSettings["ProxyServer"] == null ?
                                string.Empty : ConfigurationManager.AppSettings["ProxyServer"].ToString();
    
    
                Uri result = new Uri(_proxyServer);
                return result;
    
    
            }
    
    
    
            public bool IsBypassed(Uri host)
            {
    
                return false;
    
            }
        }
    }
