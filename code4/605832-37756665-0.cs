    public static class TypeExtensions
    {
        public static string PrettyPrint(this Type type)
        {
            var str = type.ToString();
            for (int i = 1; i < 6; i++)
            {
                str = str.Replace($"`{i}[", "<");
            }
            str = str.Replace("]", ">");
            var knownNamespaces = new[]
            {
                "System.",
                "My.Models.",
                "Domain."
            };
            foreach (var knownNamespace in knownNamespaces)
            {
                str = str.Replace(knownNamespace, string.Empty);
            }
           
            return str;
        }
    }
