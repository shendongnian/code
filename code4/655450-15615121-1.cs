    public static string SerializeObject<T>(T obj)
    {
        try
        {
            string xmlString = null;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                UTF8Encoding enc = new UTF8Encoding();
                using (StreamWriter writer = new StreamWriter(memoryStream, enc))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    xs.Serialize(writer, obj, ns);
                }
                xmlString = enc.GetString(memoryStream.ToArray());
                return xmlString;
            }
        }
        catch
        {
            return string.Empty;
        }
    }
