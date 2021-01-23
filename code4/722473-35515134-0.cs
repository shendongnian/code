    protected Boolean CorrectFileFormat(Stream inputStream)
    {
        // rewind the stream back to the very beginning of the content
        inputStream.Seek(0L, SeekOrigin.Begin);
        XmlReader reader = XmlReader.Create(inputStream);
    
        if (reader.MoveToContent() == XmlNodeType.Element && reader.Name == "DiagReport")
        {
            return true;
        }
    }
