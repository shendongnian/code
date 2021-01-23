    AppDomainSetup ads = new AppDomainSetup();
    ads.PrivateBinPath = Path.GetDirectoryName("C:\\some.doc");
    AppDomain ad2 = AppDomain.CreateDomain("AD2", null, ads);
    ProxyDomain proxy = (ProxyDomain)ad2.CreateInstanceAndUnwrap(typeof(ProxyDomain).Assembly.FullName, typeof(ProxyDomain).FullName);
    bool ok = proxy.DoMsWork("C:\\some.doc");
    AppDomain.Unload(ad2);
        public class ProxyDomain : MarshalByRefObject
        {
            public bool DoMsWork(string assemblyPath)
            {
                //Load your file and do work here
            }
        }
