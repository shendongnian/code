    public static class AssemblyUtilities {
        private static Dictionary<Assembly, string> locationByAssembly =
            new Dictionary<Assembly, string>();
        
        private static Dictionary<string, Assembly> assemblyByLocation =
            new Dictionary<string, Assembly>(StringComparer.OrdinalIgnoreCase);
        
        public static Assembly LoadFile(string location) {
            Assembly assembly;
            lock (locationByAssembly) {
                if (!assemblyByLocation.TryGetValue(location, out assembly)) {
                    byte[] bytes = ReadAllBytes(location);
                    if (bytes == null) return null;
                    byte[] pdb = ReadAllBytes(Path.ChangeExtension(location, ".pdb"));
                    assembly = ((pdb == null)? Assembly.Load(bytes): Assembly.Load(bytes, pdb));
                    locationByAssembly[assembly] = location;
                    assemblyByLocation[location] = assembly;
                }
                return assembly;
            }
        }
        public static string GetLocation(Assembly assembly) {
            if (assembly == null) return null;
            string location = assembly.Location;
            if (location == null) locationByAssembly.TryGetValue(assembly, out location);
            return location;
        }
        private static byte[] ReadAllBytes(string path) {
            try { return File.ReadAllBytes(path); }
            catch { return null; }
        }
    }
    // And if you prefer extensions...
    public static class AssemblyExtensions {
        public static string GetLocation(this Assembly self) {
            return AssemblyUtilities.GetLocation(self);
        }
    }
