    public static class Extensions
    {
        public static MethodInfo GetMethodByNameThenSig(
            this Type type,
            string name, 
            Type returnType, 
            params Type[] parameterTypes)
        {
            return type.GetMethods().Where((m) =>
            {
                if (m.Name != name)
                {
                    return false;
                }
                if (m.ReturnType != returnType)
                {
                    return false;
                }
                var parameters = m.GetParameters();
                if ((parameterTypes == null || parameterTypes.Length == 0))
                {
                    return parameters.Length == 0;
                }
                if (parameters.Length != parameterTypes.Length)
                {
                    return false;
                }
                for (int i = 0; i < parameterTypes.Length; i++)
                {
                    if (parameters[i].ParameterType != parameterTypes[i])
                    {
                        return false;
                    }
                }
                return true;
            }).Single();
        }
    }
