    for(int col = 0; col < numCols; col++)
    {
        var oxa = new List<OpenXmlAttribute>();
        oxa.Add(new OpenXmlAttribute("t",null,"str"));
        writer.WriteStartElement(c,oxa);
        writer.WriteElement(new CellValue(string.Format("R{0}C{1}", row, col)));
        writer.WriteEndElement();
    }
