    class Lister
    {
        public string ListObjectMembers(Object o)
        {
            var result = new StringBuilder();
            ProxyType proxy = o as ProxyType;
            Type type = proxy != null ? proxy.UnderlyingSystemType : o.GetType();
            result.AppendLine("Type: " + type);
            result.AppendLine("Properties:");
            foreach (PropertyInfo propertyInfo in type.GetProperties())
                result.AppendLine("   " + propertyInfo.Name);
            result.AppendLine("Methods:");
            foreach (MethodInfo methodInfo in type.GetMethods())
                result.AppendLine("   " + methodInfo.Name);
            return result.ToString();
        }
    }
