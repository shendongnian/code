    public static XElement GetDirectoryXml(DirectoryInfo dir)
    {
        var info = new XElement("dir",
                       new XAttribute("name", dir.Name));
        foreach (var file in dir.GetFiles())
            info.Add(new XElement("file",
                         new XAttribute("name", file.Name)));
        foreach (var subDir in dir.GetDirectories())
            info.Add(GetDirectoryXml(subDir));
        return info;
    }
