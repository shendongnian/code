    public static Dictionary<string, string> GetProperties(MethodInfo method)
    {
        return method.GetCustomAttributes(typeof(TestPropertyAttribute), false)
                     .Cast<TestProperty>()
                     .ToDictionary(x => x.Key, x => x.Value);
    }
