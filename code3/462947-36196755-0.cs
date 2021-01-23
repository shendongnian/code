    public static class TypeExplorer
    {
        public static string GetTypeTree<T>()
        {
            var stringBuilder = new StringBuilder();
            GetTypeTree(typeof(T), stringBuilder, 0);
            return stringBuilder.ToString();
        }
        private static void GetTypeTree(Type type, StringBuilder stringBuilder, int nestingLevel)
        {
            stringBuilder.AppendLine(new string(' ', nestingLevel) + type.Name);
            nestingLevel++;
            foreach (var nestedType in type.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic))
            {
                GetTypeTree(nestedType, stringBuilder, nestingLevel);
            }
        }
    }
