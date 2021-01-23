    public static T SetPrivateFieldValue<T>(this T target, string name, object value)
    {
        Type type = target.GetType();
        var flags = BindingFlags.NonPublic | BindingFlags.Instance;
        var field = type.GetField(name, flags);
        field.SetValue(target, value);
        return target;
    }
