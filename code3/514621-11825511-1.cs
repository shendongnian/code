    public static ApplicationSettings LoadSettings(string filePath)
    {
        XmlSerializer XSerializer = new XmlSerializer(typeof(ApplicationSettings));
        using (StreamReader strRead = new StreamReader(filePath))
        {
            var result = (ApplicationSettings)XSerializer.Deserialize(strRead);
        }
        return result;
    }
