    String dPath=@"C:\to\the\sample\directory";
    var xfiles = new My.Computer().FileSystem.GetFiles(dPath, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.dwg").Where(c => Regex.IsMatch(c,@"\d{3,}\.dwg$"));
    XElement filez = new XElement("filez");
    foreach (String f in xfiles)
    {
        var yfiles = new My.Computer().FileSystem.GetFiles(dPath, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, string.Format("{0}*.dwg",System.IO.Path.GetFileNameWithoutExtension(f))).Where(c => Regex.IsMatch(c, @"_\d+\.dwg$"));
        if (yfiles.Count() > 0)
        {
            filez.Add(new XElement("file", yfiles.Last()));            
        }
        else {
            filez.Add(new XElement("file", f));
        };
    };
    Console.Write(filez);
