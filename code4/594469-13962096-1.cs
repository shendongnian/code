    var x = new XmlReaderSettings();
    x.IgnoreWhitespace = true;  
    using (var newMemoryStream = new MemoryStream())
    {
        stream.CopyTo(newMemoryStream);
        newMemoryStream.Position = 0;
        using (var newReader = XmlReader.Create(newMemoryStream,x)) //*
        {
            Doing some stuff...
        }
    }
