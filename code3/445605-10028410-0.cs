    try
    {
        foreach (string xmlfilelisted in xmlFileList)
        {
            resultXml.Root.Add(XDocument.Load(xmlfilelisted).Root.Elements());
        }
    }
    finally
    {
        resultXml.Save(filepath);
    }
