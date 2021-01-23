    public class AssemblyAnalyser : MarshalByRefObject, IDisposable
    {
        public AssemblyAnalyser()
        {
            var evidence = new Evidence(AppDomain.CurrentDomain.Evidence);
            var appSetup = new AppDomainSetup()
            {
                ApplicationBase = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            };
            appDomain = AppDomain.CreateDomain(otherDomainFriendlyName, evidence, appSetup); 
        }
        public bool IsTestAssembly(string assemblyPath)
        {
            if (AppDomain.CurrentDomain.FriendlyName != otherDomainFriendlyName)
            {
                var analyser = appDomain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, GetType().FullName);
                return ((AssemblyAnalyser)analyser).IsTestAssembly(assemblyPath);
            }
            else
            {
                var assembly = Assembly.LoadFrom(assemblyPath);
                return ContainsTestClasses(assembly);
            }
        }
        public void Dispose()
        {
            if (AppDomain.CurrentDomain.FriendlyName != otherDomainFriendlyName)
            {
                AppDomain.Unload(appDomain);
                GC.SuppressFinalize(this);
            }
        }
        ~AssemblyAnalyser()
        {
            Dispose();
        }
        private bool ContainsTestClasses(Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
            {
                var attr = type.GetCustomAttributes(true).Select(x => x.ToString());
                if (attr.Contains("Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute"))
                    return true;
            }
            return false;
        }
        private const string otherDomainFriendlyName = "AssemblyAnalyser";
        private AppDomain appDomain;
    }
