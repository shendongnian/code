    public static bool TryFromString<T>(string value, out T convertedValue)
    {
        Type t = typeof(T);
        convertedValue = default(T);
        if (t.Name == "Nullable`1")
            t = System.Nullable.GetUnderlyingType(t);
        if (value != null)
        {
            try
            {
                convertedValue = (T)System.Convert.ChangeType(value, t, CultureInfo.CurrentCulture);
                return true;
            }
            catch
            {
            }
        }
        return false;
    }
