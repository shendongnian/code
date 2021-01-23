    XmlDocument doc = new XmlDocument();
    doc.LoadXml(your text string);
    StringBuilder sb = new StringBuilder();
    foreach (XmlNode node in doc.DocumentElement.ChildNodes)
    {
        sb.Append(char.ToUpper(node.Name[0]));
        sb.Append(node.Name.Substring(1));
        sb.Append(' ');
        sb.AppendLine(node.InnerText);
    }
    return sb;
