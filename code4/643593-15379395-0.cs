    using System;
    using System.Net;
    using System.Net.Cache;
    using System.Xml;
    using System.IO;
    namespace My.Nasmespace.Class.IO
    {
        class XmlExtendedResolver : XmlUrlResolver
        {
            bool enableHttpCaching;
            ICredentials credentials;
            private string localServerPath;
            //resolve ressource from localServerPath if it's possible
            //resolve resources from cache (if possible) when enableHttpCaching is set to true 
            //resolve resources from source when enableHttpcaching is set to false  
            public XmlExtendedResolver(bool enableHttpCaching, string serverPath)
            {
                this.enableHttpCaching = enableHttpCaching;
                localServerPath = serverPath;
            }
            public override ICredentials Credentials
            {
                set
                {
                    credentials = value;
                    base.Credentials = value;
                }
            }
            public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
            {
                if (absoluteUri == null)
                {
                    throw new ArgumentNullException("absoluteUri");
                }
                //resolve resources from cache (if possible) 
                if (absoluteUri.Scheme == "http" && enableHttpCaching && (ofObjectToReturn == null || ofObjectToReturn == typeof(Stream)))
                {
                    /*Try to resolve it from the local path if it exists*/
                    if (!string.IsNullOrEmpty(localServerPath) && absoluteUri.AbsolutePath.EndsWith(".dtd") && !absoluteUri.AbsoluteUri.StartsWith(localServerPath))
                    {
                        try { 
                            return GetEntity(new Uri(localServerPath + "/Xml/" + absoluteUri.Segments[absoluteUri.Segments.Length-1]), role, ofObjectToReturn);
                        } catch (FileNotFoundException){
                             //Fail silently to go to the web request.
                        }
                    }
                    WebRequest webReq = WebRequest.Create(absoluteUri);
                    webReq.CachePolicy = new    HttpRequestCachePolicy(HttpRequestCacheLevel.Default);
                    if (credentials != null)
                    {
                        webReq.Credentials = credentials;
                    }
                    WebResponse resp = webReq.GetResponse();
                    return resp.GetResponseStream();
                }
                //otherwise use the default behavior of the XmlUrlResolver class (resolve resources from source) 
            else
                {
                    return base.GetEntity(absoluteUri, role, ofObjectToReturn);
                }
            }
        }
    }
