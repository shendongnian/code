    public static T GetPrivateProperty<T>(object obj, string propertyName)
    {
        return (T) obj.GetType()
                      .GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic)
                      .GetValue(obj);
    }
    public static void SetPrivateProperty<T>(object obj, string propertyName, T value)
    {
        obj.GetType()
           .GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic)
           .SetValue(obj, value);
    }
