      public bool IsTestAssembly(string assemblyPath)
      {
         Assembly testDLL = Assembly.LoadFile(assemblyPath);
         foreach (Type type in testDLL.GetTypes())
         {
            if (type.GetCustomAttributes(typeof(NUnit.Framework.TestFixtureAttribute), true).Length > 0)
            {
               return true;
            }
         }
         return false;
      }
    
      public static IEnumerable<TestDll> GetTestAssembliesUsingNewAppDomain(string path)
      {
         AppDomainSetup ads = new AppDomainSetup();
         ads.PrivateBinPath = Path.GetDirectoryName("C:\\some.dll");
         AppDomain ad2 = AppDomain.CreateDomain("AD2", null, ads);
         ProxyDomain proxy = (ProxyDomain)ad2.CreateInstanceAndUnwrap(typeof(ProxyDomain).Assembly.FullName, typeof(ProxyDomain).FullName);
         bool isTdll = proxy.IsTestAssembly("C:\\some.dll");
         AppDomain.Unload(ad2);
      }
