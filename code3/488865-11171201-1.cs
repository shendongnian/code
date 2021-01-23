    public static T Next<T>(this T e) where T : struct
    {
        var t = typeof(T);
        if (!t.IsEnum) throw new ArgumentException("T must be an enumerated type");
        if (!Enum.IsDefined(t, e)) throw new ArgumentException();
        var intValue = (int)t.GetField(e.ToString()).GetValue(null);
        var enumValues = t.GetFields(BindingFlags.Public | BindingFlags.Static).Select(x => x.GetValue(null));
        var next = (T?)enumValues.Where(x => (int)x > intValue).Min();
        if (next.HasValue)
            return next.Value;
        else
            return (T)enumValues.Min();
    }
