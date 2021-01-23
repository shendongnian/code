    public static IEnumerable<YourValues> GetValues2<T>() where T : struct 
    {
        var t = typeof(T);
        if (!t.IsEnum)
            throw new ArgumentException("Not an enum type");
        return Enum.GetValues(t)
            .Cast<T>()
            .Select(x => new YourValues{
                Value = ((int)Enum.ToObject(t, x)).ToString("00"), 
                Text = Regex.Replace(x.ToString(), "([A-Z])", " $1").Trim()
                });
    }
