    internal static class KnownTypeHelper
    {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider = null)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(a => a.Namespace == "Company.Path.To.DataContractsNamespace").ToArray();
    
            return types;
        }
    }
