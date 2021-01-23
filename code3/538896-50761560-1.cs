    public static IEnumerable<MethodInfo> GetMethodsWithoutStandard(this Type t)
            {
                var std = new List<string>() {  nameof(ToString),
                                                nameof(Equals),
                                                nameof(GetHashCode),
                                                nameof(GetType)};
                return t.GetMethods().Where(x => !std.Contains(x.Name));
            }
