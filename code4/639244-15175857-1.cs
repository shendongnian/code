    public class SomeStuffCaller
    {
        public void CallDoSomeStuff(string assemblyPath)
        {
            AppDomainSetup setup = AppDomain.CurrentDomain.SetupInformation;
            //Path to the directory, containing the assembly
            setup.ApplicationBase = "...";
            //List of directories where your private references are located
            setup.PrivateBinPath = "...";
            setup.ShadowCopyFiles = "true";
            
            var reflectionDomain = AppDomain.CreateDomain("ProxyDomain", null, setup);
            
            //You should specify the ProxyDomain assembly full name
            //You can also utilize CreateInstanceFromAndUnwrap here:
            var proxyType = (ProxyType)reflectionDomain.CreateInstanceAndUnwrap(
                "ProxyDomain", 
                "ProxyType");
            proxyType.DoSomeStuff(assemblyPath);
            AppDomain.Unload(reflectionDomain);
        }
    }
