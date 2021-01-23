    public static IEnumerable<MethodInfo> GetMethods(IEnumerable<object> sequence)
    {
        return sequence.GroupBy(obj => obj.GetType())
            .SelectMany(group => group.Key.GetMethods());
    }
