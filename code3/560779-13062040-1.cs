    public static T DeserializeXml<T>(this string xml) where T : class
    {
        XmlDocument doc = new XmlDocument();
        using (MemoryStream ms = new MemoryStream())
        {
            using (StreamReader sr = new XmlSerializer(typeof(T))
            {
                T x = null;
                try
                {
                    doc.LoadXml(xml); doc.Save(ms);
                    ms.Position = 0;
                    sr = new StreamReader(ms);
                    XmlSerializer i = new XmlSerializer(typeof(T));
                    x = (T)i.Deserialize(sr);
                }
                catch (Exception) {
                    return null;
                }
            }
        }
        return x;
    }
