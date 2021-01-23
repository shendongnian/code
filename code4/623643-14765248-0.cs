    internal static class ExtensionMethods
    {
        internal static object ConvertToRCW(this object o)
        {
            return Marshal.CreateWrapperOfType(o, o.ToCLSID().AsType());
        }
        
        internal static Guid ToCLSID(this object o)
        {
            Guid guid = Guid.Empty;
            var p = o as IPersist;
            if (p != null)
                p.GetClassID(out guid);
            return guid;
        }
    
        internal static Type AsType(this Guid guid)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in assembly.GetLoadableTypes())
                {
                    if ( type.GUID == guid )
                        return type;
                }
            }
            return null;
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
