    var stringArray = new string[100]; //value of the string
    var stringArrayIdentifier = new string[100]; //refers to what you will call the field 
    //<identifier>string</identifier>
    var settings = new XmlWriterSettings
                       {Indent = true, IndentChars = "\t", NewLineOnAttributes = false};
    using (XmlWriter writer = XmlWriter.Create("PATH", settings))
    {
        writer.WriteStartDocument();
        writer.WriteStartElement("Title");
        writer.WriteAttributeString("Name", "GiveItAName");
        foreach (int i = 0; i < stringArray.Length; i++)
        {
            writer.WriteStartElement(stringArrayIdentifier[i]);
            writer.WriteString(stringArray[i]);
            writer.WriteEndElement();
        }
        writer.WriteEndElement();
        writer.WriteEndDocument();
    }
