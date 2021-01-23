    static IEnumerable<string> GetNames<T>(T value) where T : struct
    {
        return typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static)
                        .Where(f => f.GetValue(null).Equals(value))
                        .Select(f => f.Name);
    }
