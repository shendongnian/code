    public static T GetValue<T>(this XElement element, string name)
    {
        string value = (string)element.Element(name);
        return (T)Convert.ChangeType(value, typeof(T));
    }
