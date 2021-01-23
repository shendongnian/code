    public static GUIControl CreateControl2<T>(T skinXml) where T : XmlControl
    {
        var controlType = Assembly.GetExecutingAssembly().DefinedTypes
            .Where(t => t.BaseType == typeof(GUIControl) && t.GetCustomAttribute<XmlControlTypeAttribute>().XmlType.Equals(typeof(T)))
            .FirstOrDefault();
        return (GUIControl)Activator.CreateInstance(controlType, new[] { skinXml }, null);
    }
