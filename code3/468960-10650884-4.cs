    public delegate void UpdateUI(int progress);
    private void RunOneAfterAnotherAsync()
    {
        Task<XmlElement> task = Task.Factory.StartNew<XmlElement>(CreateXMLBW);
        task.ContinueWith(CreateRarBW);
    }
    private XmlElement CreateXMLBW()
    {
        // your code
        // progress
        progressBar1.Invoke((UpdateUI)UpdateProgressBar, new object[] {progressValue});
        // result
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
    public void UpdateProgressBar(int value)
    {
        this.progressBar1.Value = value;
    }
