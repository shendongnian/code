    public static IEnumerable<MethodInfo> GetMethods<T>(IEnumerable<T> sequence)
    {
        return sequence.GroupBy(obj => obj.GetType())
            .SelectMany(group => group.Key.GetMethods());
    }
