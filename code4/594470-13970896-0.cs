    var xmlReaderSettings = new XmlReaderSettings();
    stream.Position = 0;//*
    xmlReaderSettings.IgnoreWhitespace = true;
    using (var newMemoryStream = new MemoryStream())
    {
        stream.CopyTo(newMemoryStream);
        newMemoryStream.Position = 0;  //*
        using (var newReader = XmlReader.Create(newMemoryStream, xmlReaderSettings))
        {
            newReader.MoveToContent(); //*
            Doing some stuff...
        }
    }
