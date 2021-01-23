    public static class ReflectionExtensions {
        public static object InvokeWithNamedParameters(this MethodBase self, object obj, IDictionary<string, object> namedParameters) { 
            return self.Invoke(obj, MapParameters(self, namedParameters));
        }
        public static object[] MapParameters(MethodBase method, IDictionary<string, object> namedParameters)
        {
            string[] paramNames = method.GetParameters().Select(p => p.Name).ToArray();
            object[] parameters = new object[paramNames.Length];
            for (int i = 0; i < parameters.Length; ++i) 
            {
                parameters[i] = Type.Missing;
            }
            foreach (var item in namedParameters)
            {
                var paramName = item.Key;
                var paramIndex = Array.IndexOf(paramNames, paramName);
                parameters[paramIndex] = item.Value;
            }
            return parameters;
        }
    }
