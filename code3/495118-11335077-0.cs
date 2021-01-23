    var MyNpcBaseInfoInstance = new NpcBaseInfo();
    // ...
    SaveAnyObject(MyNpcBaseInfoInstance, "file.xml");
    public void SaveAnyObject(object objGraph, string fileName)
    {
        XmlSerializer xmlFormat = new XmlSerializer(objGraph.GetType());
        using(Stream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
        {
                xmlFormat.Serialize(fileStream, objGraph);
        }
    }
