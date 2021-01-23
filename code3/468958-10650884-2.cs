    private void RunOneAfterAnother()
    {
        Task<XmlElement> task = Task.Factory.StartNew<XmlElement>(CreateXMLBW);
        task.ContinueWith(CreateRarBW);
    }
    private XmlElement CreateXMLBW()
    {
        // your code
        XmlDocument doc = new XmlDocument();
        return doc.CreateElement("element");
    }
    private void CreateRarBW(Task<XmlElement> task)
    {
        CreateRarBW(task.Result);
    }
    private void CreateRarBW(XmlElement arg)
    {
        // your code
    }
