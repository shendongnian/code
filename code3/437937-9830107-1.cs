    foreach (string f in Directory.GetFiles(d, "*.xml"))
    {
        string extension = Path.GetExtension(f);
        if (extension != null && (extension.Equals(".xml")))
        {
            fileList.Add(f);
        }
    } 
    foreach (string d in Directory.GetDirectories(sDir))
    {
        DirSearch(d);
    }
