    using (var fs = File.Create(fileName))
    {
        using (var gz = new GZipStream(fs, CompressionMode.Compress))
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (var writer = XmlWriter.Create(gz, settings))
            {
                // write xml here
            }
        }
    }
