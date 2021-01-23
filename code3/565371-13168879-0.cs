    var writer = XmlWriter.Create("c:\temp\text.xml");
    writer.WriteStartElement("data");
    writer.WriteStartElement("Annual Enrollment");
    writer.WriteStartElement("row");
    writer.WriteElementString("column", "value1");
    writer.WriteElementString("column", "value2");
    writer.WriteElementString("column", "value3");
    writer.WriteEndElement(); // row
    writer.WriteStartElement("row");
    writer.WriteElementString("column", "value1");
    writer.WriteElementString("column", "value2");
    writer.WriteElementString("column", "value3");
    writer.WriteEndElement(); // row
    writer.WriteEndElement(); // Annual Enrollment
    writer.WriteEndElement(); // data
