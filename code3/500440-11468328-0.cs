    public static string SerializeToXml(WebServiceType[] webServices)
    {
        // Make a MethodCheck object to hold the services.
        // This ensures that you get a top-level <MethodCheck> tag in the XML.
        MethodCheckType container = new MethodCheckType();
        container.WebService = webServices;
        using (var writer = new StringWriter())
        {
            var serializer = new XmlSerializer(typeof(MethodCheckType));
            // Note that you're serializing, not deserializing.
            serializer.Serialize(writer, container);
            writer.Flush();
            return writer.ToString();
        }
    }
