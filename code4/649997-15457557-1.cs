    List<string> matches = new List<string>(); 
    DirectoryInfo C = new DirectoryInfo("C:\\");
    var rootFiles = C.GetFiles();
    var rootDirs = C.GetDirectories("*", SearchOption.TopDirectoryOnly).Where(dir => !dir.Name.Equals("System Volume Information") && !dir.Name.Equals("RECYCLER") && !dir.Name.Equals("WINDOWS"));
    
    foreach (var rf in rootFiles)
    {
        if (rf.Name.Equals("MCRInstaller.exe"))
        {
            matches.Add(rf.FullName);
        }
    }
    foreach (var rdir in rootDirs)
    {
        var dirFiles = rdir.GetFiles("*", SearchOption.AllDirectories);
        foreach (var aFile in dirFiles)
        {
            if (aFile.Name.Equals("MCRInstaller.exe"))
            {
                matches.Add(aFile.FullName);
            }
        }
    }
    foreach (match in matches)
    {
        //do some stuff with your list of matches
    }
