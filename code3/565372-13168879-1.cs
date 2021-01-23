    var docBuilder = new StringBuilder();
    using (var writer = XmlWriter.Create(docBuilder))
    {
        writer.WriteStartElement("data");
        writer.WriteStartElement("AnnualEnrollment");
        foreach (var row in dataTable.Rows)
        {
            writer.WriteStartElement("row");
            foreach (var item in row.ItemArray)
                writer.WriteElementString("column", item);
            writer.WriteEndElement(); // row
        }
        writer.WriteEndElement(); // Annual Enrollment
        writer.WriteEndElement(); // data
    }
    docBuilder.Replace("<AnnualEnrollment>", "<Annual Enrollment>");
