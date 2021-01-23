    public void LoadSettings(string filePath)
    {
        XmlSerializer XSerializer = new XmlSerializer(typeof(ApplicationSettings));
        StreamReader strRead = new StreamReader(filePath);
        ApplicationSettings settingsRead = (ApplicationSettings)XSerializer.Deserialize(strRead);
        foreach (var field in typeof(ApplicationSettings).GetFields())
        {
            field.SetValue(this, field.GetValue(settingsRead));
        }
        strRead.Close();
    }
