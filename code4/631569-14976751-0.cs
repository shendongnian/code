        public class NSScanner
        {
            public static List<Type> GetLoadedTypes(AppDomain appDomain)
            {
                return _getLoadedTypes(appDomain);
            }
            public static List<Type> GetPublicLoadedTypes(AppDomain appDomain)
            {
                return _getLoadedTypes(appDomain, true);
            }
            public static List<string> GetUniqueNamespaces(IEnumerable<Type> types)
            {
                var uniqueNamespaces = new ConcurrentBag<string>();
                Parallel.ForEach(types, type =>
                {
                    if (!uniqueNamespaces.Contains(type.Namespace) && !string.IsNullOrEmpty(type.Namespace))
                        uniqueNamespaces.Add(type.Namespace);
                });
                var sortedList = uniqueNamespaces.OrderBy(o => o).ToList();
                return sortedList;
            }
            private static List<Type> _getLoadedTypes(AppDomain appDomain, bool onlyPublicTypes = false)
            {
                var loadedAssemblies = appDomain.GetAssemblies();
                var loadedTypes = new List<Type>();
                Parallel.ForEach(loadedAssemblies, asm =>
                {
                    Type[] asmTypes;
                    if (onlyPublicTypes)
                        asmTypes = asm.GetExportedTypes();
                    else
                        asmTypes = asm.GetTypes();
                    loadedTypes.AddRange(asmTypes);
                });
                return loadedTypes;
            }
        }
