    private static Dictionary<Type, Func<XmlControl, GUIControl>> _dictionary = new Dictionary<Type, Func<XmlControl, GUIControl>>()
                                                                                        {
                                                                                            {typeof (XmlControlImpl), x => new GUIControl(x)},
                                                                                            {typeof (XmlGroup), x => new GUIGroup(x)},
                                                                                        }; 
    public static GUIControl CreateControl<T>(T skinXml) where T : XmlControl
    {
        Func<XmlControl, GUIControl> builder;
        if (!_dictionary.TryGetValue(typeof(T), out builder))
            throw new KeyNotFoundException("");
        return builder(skinXml);
    }                            
