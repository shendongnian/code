    public T EnumFromString<T>(string value) where T : struct
    {
        string noSpace = value.Replace(" ", "");
        if (Enum.GetNames(typeof(T)).Any(x => x.ToString().Equals(noSpace)))
        {
            return (T)Enum.Parse(typeof(T), noSpace);
        }
        return default(T);
    }
