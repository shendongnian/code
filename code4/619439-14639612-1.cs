    internal void SaveSettings()
    {
        var serializer = new XmlSerializer(typeof(AppSettings));
        using (var stream = File.OpenWrite(GetSettingsFile()))
        {
            serializer.Serialize((Stream)stream, this);
        }
    }
