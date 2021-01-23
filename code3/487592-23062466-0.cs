    public void WriteXml(XmlWriter writer)
    {
        writer.WriteAttributeString("Version", vesrion.ToString(CultureInfo.InvariantCulture));
        writer.WriteStartElement("MyCollection");
        foreach (int collint in Testcoll)
        {
            writer.WriteElementString("int", collint.ToString(CultureInfo.InvariantCulture));
        }
        writer.WriteEndElement();
    }
