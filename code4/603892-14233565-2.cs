    public static GUIControl CreateControl<T>(T skinXml) where T : XmlControl
    {
        return (GUIControl)Activator.CreateInstance(skinXml.ControlType(),
                                         new[]{skinXml},null);
    }
