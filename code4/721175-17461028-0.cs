    try
    {
        var file = "Your xml path";
        var settings = new XmlReaderSettings { DtdProcessing = DtdProcessing.Ignore, XmlResolver = null };
        using (var reader = XmlReader.Create(new StreamReader(file), settings))
        {
            var document = new XmlDocument();
            document.Load(reader);
        }
    }
    catch (Exception exc)
    {
        //show the exception here
    }
