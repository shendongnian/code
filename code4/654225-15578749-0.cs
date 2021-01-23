    [AttributeUsage(AttributeTargets.All)]
    public class ModuleInitializerAttribute : Attribute
    {
        private readonly string _assemblyName;
        private readonly Func<Module, bool> _modulePredicate;
        private readonly string _typeName;
        private readonly string _methodName;
        /// <summary>
        /// Only used in my test rig so I can make sure this assembly is loaded
        /// </summary>
        public static void CallMe() {}
        public ModuleInitializerAttribute(string assemblyName, string moduleName, string typeWithMethod, string methodToInvoke)
        {
            _assemblyName = assemblyName;
            _modulePredicate = mod => moduleName == null || mod.Name.Equals(moduleName, StringComparison.OrdinalIgnoreCase);
            _typeName = typeWithMethod;
            _methodName = methodToInvoke;
            AppDomain.CurrentDomain.AssemblyLoad += OnAssemblyLoad;
            AppDomain.CurrentDomain.DomainUnload += AppDomainUnloading;
            CheckLoadedAssemblies();
        }
        private void CheckLoadedAssemblies()
        {
            AppDomain.CurrentDomain.GetAssemblies().ToList().ForEach(this.CheckAssembly);
        }
        private void AppDomainUnloading(object sender, EventArgs e)
        {
            // Unwire ourselves
            AppDomain.CurrentDomain.AssemblyLoad -= this.OnAssemblyLoad;
            AppDomain.CurrentDomain.DomainUnload -= AppDomainUnloading;
        }
        private void OnAssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            CheckAssembly(args.LoadedAssembly);
        }
        private void CheckAssembly(Assembly asm)
        {
            if (asm.FullName == _assemblyName)
            {
                var module = asm.GetModules().FirstOrDefault(_modulePredicate);
                if (module != null)
                {
                    var type = module.GetType(string.Concat(asm.GetName().Name, ".", _typeName));
                    if (type != null)
                    {
                        var method = type.GetMethod(_methodName);
                        if (method != null)
                        {
                            method.Invoke(null, null);
                        }
                    }
                }
            }
        }
    }
