    void test2()
    {
        XmlDocument doc = new XmlDocument();
        XmlNode root = doc.AppendChild(doc.CreateElement("root"));
        doc.DocumentElement.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
        doc.DocumentElement.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
        serializeAppend(root, new object[] { 1, "two", 3.0 });  // serialize object and append it to XmlNode
        var obj = deserialize<object[]>(root.ChildNodes[0]);    // deserialize XmlNode to object
    }
    T deserialize<T>(XmlNode node)
    {
        XPathNavigator nav = node.CreateNavigator();
        using (var reader = nav.ReadSubtree())
        {
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(reader);
        }
    }
    void serializeAppend(XmlNode parentNode, object obj)
    {
        XPathNavigator nav = parentNode.CreateNavigator();
        using (var writer = nav.AppendChild())
        {
            var serializer = new XmlSerializer(obj.GetType());
            writer.WriteWhitespace("");
            serializer.Serialize(writer, obj);
            writer.Close();
        }
    }
