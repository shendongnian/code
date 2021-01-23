    using System;
    using System.IO;
    using System.IO.Packaging;
    using System.Net;
    using System.Xml;
    
    namespace XmlResolution
    {
        class XmlResourceResolver : XmlResolver
        {
            private static readonly string FileScheme = "file";
            private static readonly string PackScheme = PackUriHelper.UriSchemePack;
            private ICredentials credentials;
    
            public override ICredentials Credentials
            {
                set { this.credentials = value; }
            }
    
            public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
            {
                if (absoluteUri.Scheme == FileScheme)
                {
                    return File.OpenRead(absoluteUri.LocalPath);
                }
                else if (absoluteUri.Scheme == PackScheme)
                {
                    return System.Windows.Application.GetResourceStream(absoluteUri).Stream;
                }
    
                return null;
            }
        }
    }
