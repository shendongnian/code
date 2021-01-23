    var x_settings = new XmlWriterSettings();
    x_settings.NewLineChars = Environment.NewLine;
    x_settings.NewLineOnAttributes = true;
    x_settings.NewLineHandling = NewLineHandling.None;
    x_settings.CloseOutput = true;
    x_settings.Indent = true;
    x_settings.NewLineOnAttributes = true;
    using (XmlWriter writer = XmlWriter.Create(outputFilename, x_settings))
    {
        using (XmlTextWriterFull2 xmlTextWriterFull = new XmlTextWriterFull2(writer))
        {
            var x_serial = new XmlSerializer(typeof(XmlObject));
            x_serial.Serialize(xmlTextWriterFull, obj);
        }
    }
