    public static XmlDocument SerializeToXmlDocument<XmlEntity>(XmlEntity o)
    {
        XmlDocument xdoc;
        SerializeWrapper<XmlEntity> wrapper = new SerializeWrapper<XmlEntity>();
        wrapper.XmlObject = o;
        XmlSerializer xs = new XmlSerializer(wrapper.GetType());
        using (MemoryStream ms = new MemoryStream())
        {
            xs.Serialize(ms, wrapper);
            xdoc = new XmlDocument();
            ms.Position = 0;
            xdoc.Load(ms);
        }
        return xdoc;
    }
