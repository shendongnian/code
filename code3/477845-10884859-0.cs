    public static void SaveBehaviors(ObservableCollection<Param> listParams) 
    { 
        XmlSerializer _paramsSerializer = new XmlSerializer(typeof(ContainingType)); 
        var c = new ContainingType(listParams); 
        c.ExtraInformation = whatever....; 
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); 
        path += "\\test.xml"; 
        using (TextWriter writeFileStream = new StreamWriter(path)) 
        { 
            _paramsSerializer.Serialize(writeFileStream, c); 
        } 
    } 
