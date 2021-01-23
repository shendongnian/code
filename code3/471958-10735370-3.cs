    public Stream GetXml()
    {
        string filePath = "document.xml";
        try
        {
            FileStream xmlFileStream = File.OpenRead(filePath);
            return xmlFileStream;
        }
        catch (IOException ex)
        {
            // Exception handling logic
        }
    }
