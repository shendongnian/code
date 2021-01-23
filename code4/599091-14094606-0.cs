    AppDomainSetup ads = new AppDomainSetup();
    ads.PrivateBinPath = Path.GetDirectoryName("C:\\some.dll");
    AppDomain ad2 = AppDomain.CreateDomain("AD2", null, ads);
    ProxyDomain proxy = (ProxyDomain)ad2.CreateInstanceAndUnwrap(typeof(ProxyDomain).Assembly.FullName, typeof(ProxyDomain).FullName);
    bool ok = proxy.LoadDll("C:\\some.dll");
    AppDomain.Unload(ad2);
    public class ProxyDomain : MarshalByRefObject
    {
        public bool LoadDll(string assemblyPath)
        {
             Assembly myDLL = Assembly.LoadFile(assemblyPath);
            //use your dll here
        }
    }
