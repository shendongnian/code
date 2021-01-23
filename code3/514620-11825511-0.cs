    public static ApplicationSettings LoadSettings(string filePath)
    {
        XmlSerializer XSerializer = new XmlSerializer(typeof(ApplicationSettings));
        StreamReader strRead = new StreamReader(filePath);
        var result = (ApplicationSettings)XSerializer.Deserialize(strRead);
        strRead.Close();
        return result;
    }
