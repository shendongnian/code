    using (XmlWriter writer = XmlWriter.Create(ms, settings))
    {
        long startPos = ms.Position;
        // write an element
        writer.WriteStartElement("url", myUrl);
        writer.WriteEndElement();
        writer.Flush();  // make sure data is flushed to the stream
        long endPos = ms.Position;
    }
