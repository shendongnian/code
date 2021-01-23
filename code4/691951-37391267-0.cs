    async Task TestWriter(Stream stream, Stream sourceDocument)
    {
    	XmlWriterSettings settings = new XmlWriterSettings();
    	settings.Async = true;
    	using (XmlWriter writer = XmlWriter.Create(stream, settings))
    	{
    		writer.WriteStartElement("pf", "root", "http://ns");
    		writer.WriteStartElement(null, "sub", null);
    		writer.WriteAttributeString(null, "att", null, "val");
    		writer.WriteString("text");
    		writer.WriteEndElement();
    
    		// Write the source document
    		writer.WriteStartElement(null, "SourceDocument", null);
    		Byte[] buffer = new Byte[4096];
    		int bytesRead = await sourceDocument.ReadAsync(buffer, 0, 4096);
    		while (bytesRead > 0)
    		{
    			await writer.WriteBase64Async(buffer, 0, bytesRead);
    			bytesRead = await sourceDocument.ReadAsync(buffer, 0, 4096);
    		}
    		writer.WriteEndElement(); // SourceDocument
    		writer.WriteEndElement(); // pf
    		await writer.FlushAsync();
    	}
    }
