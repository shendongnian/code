    public static class TypeExtensions
    {
        public static MethodInfo GetMethodByString(
            this Type type, string methodString)
        {
            return type.GetMethods()
                .Where(mi => MethodToString(mi) == methodString)
                .SingleOrDefault();
        }
        public static string MethodToString(MethodInfo mi)
        {
            var b = new StringBuilder();
            b.Append(mi.Name);
            if (mi.IsGenericMethodDefinition)
                b.AppendFormat("[{0}]",
                    string.Join(", ", mi.GetGenericArguments()
                    .Select(TypeToString)));
            b.AppendFormat("({0})", string.Join(", ", mi.GetParameters()
                .Select(ParamToString)));
            return b.ToString();
        }
        public static string TypeToString(Type t)
        {
            var b = new StringBuilder();
            b.AppendFormat("{0}", t.Name);
            if (t.IsGenericType)
                b.AppendFormat("[{0}]",
                    string.Join(", ", t.GetGenericArguments()
                    .Select(TypeToString)));
            return b.ToString();
        }
        public static string ParamToString(ParameterInfo pi)
        {
            return TypeToString(pi.ParameterType).Replace("&", " ByRef");
        }
    }
