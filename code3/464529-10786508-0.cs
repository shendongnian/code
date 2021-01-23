    // Open up the same file and remove xml auto-formatting
    XmlReader reader = XmlReader.Create(readFileName);
    XmlTextWriter writer = new XmlTextWriter(writeFileName, null);
    while (reader.Read())
    {
	switch (reader.NodeType)
	{
		case XmlNodeType.Element:
			// if 1st node after openening tag is analyst name then setup a linefeed
			if (reader.Name.Equals(Path.GetFileNameWithoutExtension(readerFileName)))
			{
				writer.WriteStartElement(reader.Name);
				writer.WriteString("\r\n");
			}
			else
			{
				// setup linefeed after every element
				writer.WriteStartElement(reader.Name);
				writer.WriteAttributes(reader, true);
				if (reader.IsEmptyElement)
				{
					writer.WriteEndElement();
					writer.WriteString("\r\n");
				}
			}
			break;
		case XmlNodeType.Text:
			writer.WriteString(reader.Value);
			break;
		case XmlNodeType.EndElement:
			writer.WriteEndElement();
			break;
		// handles opening xml tag
		case XmlNodeType.XmlDeclaration:
		case XmlNodeType.ProcessingInstruction:
			writer.WriteProcessingInstruction(reader.Name, reader.Value);
			writer.WriteString("\r\n");
			break;
	}
    }
    // close reader & writer
    writer.Flush();
    reader.Close();
