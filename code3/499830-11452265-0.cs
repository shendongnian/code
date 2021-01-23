    string rootPath = @"......";
    XElement xRoot = new XElement("Root",new XAttribute("Path",rootPath));
    RecurseDirs(rootPath, xRoot);
    var xmlString = xRoot.ToString();
    void RecurseDirs(string root, XElement xRoot)
    {
        foreach (var dir in Directory.EnumerateDirectories(root))
        {
            XElement xdir = new XElement("Directory",
                                            new XAttribute("Name",Path.GetFileName(dir)),
                                            new XAttribute("CreationTime",Directory.GetCreationTime(dir)));
            xRoot.Add(xdir);
            RecurseDirs(dir,xdir);
        }
        foreach (var dir in Directory.EnumerateFiles(root))
        {
            XElement xfile = new XElement("File", 
                new XAttribute("Name", Path.GetFileName(dir)),
                new XAttribute("CreationTime", File.GetCreationTime(dir)));
            xRoot.Add(xfile);
        }
    }
