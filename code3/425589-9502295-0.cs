    public static T AssembleFlagsEnum<T>(IEnumerable<string> names) where T : struct
    {
        return (T)(object)names.Aggregate(0, 
           (valSoFar, name) => valSoFar | Convert.ToInt32(Enum.Parse(typeof(T), name)));
    }
