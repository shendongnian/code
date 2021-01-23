    public static class ControllerTypeCache
    {
        private static object _syncRoot = new object();
        private static Type[] _cache;
        public static IEnumerable<Type> GetControllerTypes()
        {
            if (_cache == null)
            {
                lock (_syncRoot)
                {
                    if (_cache == null)
                    {
                        _cache = GetControllerTypesWithReflection();
                    }
                }
            }
            return new ReadOnlyCollection<Type>(_cache);
        }
        private static Type[] GetControllerTypesWithReflection()
        {
            var typesSoFar = Type.EmptyTypes;
            var assemblies = BuildManager.GetReferencedAssemblies();
            foreach (Assembly assembly in assemblies) 
            {
                Type[] typesInAsm;
                try 
                {
                    typesInAsm = assembly.GetTypes();
                }
                catch (ReflectionTypeLoadException ex) 
                {
                    typesInAsm = ex.Types;
                }
                typesSoFar = typesSoFar.Concat(typesInAsm).ToArray();
            }
            return typesSoFar
                .Where(t => t != null && 
                            t.IsPublic && 
                            !t.IsAbstract && 
                            typeof(IController).IsAssignableFrom(t)
                )
                .ToArray();
        }
    }
