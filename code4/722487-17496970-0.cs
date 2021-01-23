    public static void WriteDataXml(
        string name, string title, string comment, string path)
    {
        XDocument xdoc = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XElement("Blog",
                new XElement("Title", title),
                new XElement("Name", name),
                new XElement("Image", path),
                new XElement("Comment", comment)));
        string filename = Server.MapPath(@".\blog\") + "comments.xml";
        xdoc.Save(filename);
    }
