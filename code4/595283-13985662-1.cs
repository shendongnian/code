    public interface INamed { } //Marker interface
    public static class GetNamedHelper
    {
        private static IEnumerable<Type> GetAssemblyTypes(IEnumerable<Assembly> assemblies)
        {
            if (assemblies == null) yield break;
            foreach (var assembly in assemblies.Where(assembly => assembly != null))
            {
                IEnumerable<Type> types;
                try
                {
                    types = assembly.GetTypes().Where(t => t != null);
                }
                catch (ReflectionTypeLoadException rtle)
                {
                    types = rtle.Types.Where(t => t != null);
                }
                foreach (var type in types)
                    yield return type;
            }
        }
        private static readonly Type namedMarkerInterface = typeof (INamed);
        public static IEnumerable<string> GetNames(params Assembly[] assemblies)
        {
            var types = GetAssemblyTypes(assemblies)
                .Where(t => t.GetInterfaces().Any(intf => intf == namedMarkerInterface));
            foreach (var type in types)
            {
                //ex. public static string Name
                var prop = type.GetProperty("Name", BindingFlags.Public | BindingFlags.Static);
                if (prop == null || !prop.CanRead) continue;
                yield return prop.GetValue(null, null) as string;
                //ex. public const string Name
                var field = type.GetField("Name", BindingFlags.Public);
                if (field == null || !field.IsStatic) continue;
                yield return field.GetValue(null) as string;
            }
        }
    }
