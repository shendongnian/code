    static void Main(string[] args)
    {
        var currentDir = Directory.GetCurrentDirectory();
        var xDoc = XDocument.Load(string.Format(Path.Combine(currentDir, "Hosts.xml")));
        var threads = new List<Thread>();
        foreach (XElement host in xDoc.Descendants("Host"))
        {
            var hostID = (int) host.Attribute("id");
            var extension = (string) host.Element("Extension");
            var folderPath = (string) host.Element("FolderPath");
            var thread = new Thread(DoWork)
                             {
                                 Name = string.Format("samplethread{0}", hostID)
                             };
            thread.Start(new FileInfo
                             {
                                 HostId = hostID,
                                 Extension = extension,
                                 FolderPath = folderPath
                             });
            threads.Add(thread);
        }
        //Carry on with your other work, then wait for worker threads
        threads.ForEach(t => t.Join());
    }
    static void DoWork(object threadState)
    {
        var fileInfo = threadState as FileInfo;
        if (fileInfo != null)
        {
            //Do stuff here
        }
    }
    class FileInfo
    {
        public int HostId { get; set; }
        public string Extension { get; set; }
        public string FolderPath { get; set; }
    }
