        public static readonly List<Assembly> PluginAssemblies = new List<Assembly>();
        public static List<string> PluginNames()
        {
            return PluginAssemblies.Select(
                pluginAssembly => pluginAssembly.GetName().Name)
                .ToList();
        }
        public static void Init()
        {
            var fullPluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Areas");
            foreach (var file in Directory.EnumerateFiles(fullPluginPath, "*Plugin*.dll", SearchOption.AllDirectories))
                PluginAssemblies.Add(Assembly.LoadFile(file));
            PluginAssemblies.ForEach(BuildManager.AddReferencedAssembly);
            // Add assembly handler for strongly-typed view models
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolve;
        }
        private static Assembly AssemblyResolve(object sender, ResolveEventArgs resolveArgs)
        {
            var currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            // Check we don't already have the assembly loaded
            foreach (var assembly in currentAssemblies)
            {
                if (assembly.FullName == resolveArgs.Name || assembly.GetName().Name == resolveArgs.Name)
                {
                    return assembly;
                }
            }
            return null;
        }
    }
