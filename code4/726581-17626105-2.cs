    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    
    internal static class AssemblyLoader
    {
        internal static void RegisterAssemblyLoader()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve -= OnResolveAssembly;
            currentDomain.AssemblyResolve += OnResolveAssembly;
        }
    
        private static Assembly OnResolveAssembly(object sender, ResolveEventArgs args)
        {
            return LoadAssemblyFromManifest(args.Name);
        }
    
        private static Assembly LoadAssemblyFromManifest(string targetAssemblyName)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = new AssemblyName(targetAssemblyName);
    
            string resourceName = DetermineEmbeddedResourceName(assemblyName, executingAssembly);
    
            using (Stream stream = executingAssembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                    return null;
    
                byte[] assemblyRawBytes = new byte[stream.Length];
                stream.Read(assemblyRawBytes, 0, assemblyRawBytes.Length);
    
    
                return Assembly.Load(assemblyRawBytes);
            }
    
        }
    
        private static string DetermineEmbeddedResourceName(AssemblyName assemblyName, Assembly executingAssembly)
        {
            //This assumes you have the assemblies in a folder named "EmbeddedAssemblies"
            string resourceName = string.Format("{0}.EmbeddedAssemblies.{1}.dll",
                                                executingAssembly.GetName().Name, assemblyName.Name);
    
            //This logic finds the assembly manifest name even if it's not an case match for the requested assembly                          
            var matchingResource = executingAssembly.GetManifestResourceNames()
                                                    .FirstOrDefault(res => res.ToLower() == resourceName.ToLower());
    
            if (matchingResource != null)
            {
                resourceName = matchingResource;
            }
            return resourceName;
        }
    }
