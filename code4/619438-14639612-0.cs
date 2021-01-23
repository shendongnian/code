    internal static AppSettings GetInstance()
    {
        if (!File.Exists(GetSettingsFile()))
            return null;
        var serializer = new XmlSerializer(typeof(AppSettings));
        using (var stream = File.OpenRead(GetSettingsFile()))
        {
            return (AppSettings)serializer.Deserialize(stream);
        }
    }
