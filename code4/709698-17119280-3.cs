    public static string Serialize(dynamic o, string rootAttr, bool OmitXmlDeclaration = false, Type typeType = null)
    {
        if (typeType == null) typeType = o.GetType();
        StringBuilder sb = new StringBuilder();
        XmlWriterSettings xws = new XmlWriterSettings();
        xws.OmitXmlDeclaration = OmitXmlDeclaration;
        using (XmlWriter writer = XmlWriter.Create(sb, xws))
        {
            try
            {
                new XmlSerializer(o.GetType(), null, new Type[] { typeType }, new XmlRootAttribute(rootAttr), "").Serialize(writer, o);
                //new XmlSerializer(o.GetType(), new XmlRootAttribute(rootAttr)).Serialize(writer, o);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
                Console.WriteLine(e.StackTrace);
            }
        }
        return fstr;
    }
