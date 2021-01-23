    [assembly:AssemblyFileVersion("fred")]
    static class program
    {
        static void Main()
        {
            var ass = Assembly.GetExecutingAssembly();
            var attributes = ass.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false).Cast<AssemblyFileVersionAttribute>();
            var versionAttribute = attributes.Single();
            var ver = new Version(versionAttribute.Version);        
        }
    }
