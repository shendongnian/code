    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xml);
    DataTable table = new DataTable();
    foreach(XmlElement child in doc.DocumentElement.SelectNodes("column"))
    {
        table.Columns.Add(child.InnerText, ParseType(child.GetAttribute("Type")));
    }
    ....
    static Type ParseType(string type)
    {
        switch(type)
        {
            case "String": return typeof(string);
            case "Int32": return typeof(int);
            default: throw new NotSupportedException(type ?? "(null)");
        }
    }
