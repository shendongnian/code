                int cnt = CountCompatible(parameter.ParameterType, sourceType.GetInterfaces()) +
                          CountCompatible(parameter.ParameterType, sourceType.GetBaseTypes()) +
                          CountCompatible(parameter.ParameterType, new Type[] { sourceType });
                [...]
        private static int CountCompatible(Type dst, IEnumerable<Type> types)
        {
            int cnt = 0;
            foreach (var t in types)
            {
                if (dst.IsAssignableFrom(t))
                {
                    ++cnt;
                }
            }
            return cnt;
        }
