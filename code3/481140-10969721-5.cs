    static void Main(string[] args)
    {
        var currentDir = Directory.GetCurrentDirectory();
        var xDoc = XDocument.Load(string.Format(Path.Combine(currentDir, "Hosts.xml")));
        var taskFactory = new TaskFactory();
        foreach (XElement host in xDoc.Descendants("Host"))
        {
            var hostId = (int) host.Attribute("id");
            var extension = (string) host.Element("Extension");
            var folderPath = (string) host.Element("FolderPath");
            taskFactory.StartNew(() => DoWork(hostId, extension, folderPath));
        }
        //Carry on with your other work
    }
    static void DoWork(int hostId, string extension, string folderPath)
    {
        //Do stuff here
    }
