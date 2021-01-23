    internal static class ExtensionMethods
    {
        internal static object ConvertToRCW(this object o)
        {
            var guid = o.GetCLSID();
            if (guid != Guid.Empty)
            {
                return Marshal.CreateWrapperOfType(o, o.GetTypeFromGuid(guid));
            }
            else
            {
                return o;
            }
        }
    
        internal static Guid GetCLSID(this object o)
        {
            Guid guid = Guid.Empty;
            var p = o as IPersist;
            if (p != null)
                p.GetClassID(out guid);
            return guid;
        }
    
        internal static Type GetTypeFromGuid(this object o, Guid guid)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetLoadableTypes();
                foreach (var type in types)
                {
                    if (type.GUID == guid)
                        return type;
                }
            }
            return o.GetType();
        }
    
        internal static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }
    }
