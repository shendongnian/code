    string match; 
    bool isMatched = false;
    DirectoryInfo C = new DirectoryInfo("C:\\");
    var rootFiles = C.GetFiles();
    var rootDirs = C.GetDirectories("*", SearchOption.TopDirectoryOnly).Where(dir => !dir.Name.Equals("System Volume Information") && !dir.Name.Equals("RECYCLER") && !dir.Name.Equals("WINDOWS"));
    
    foreach (var rf in rootFiles)
    {
        if (rf.Name.Equals("MCRInstaller.exe"))
        {
            match = rf.FullName;
            break;
        }
    }
    foreach (var rdir in rootDirs)
    {
        var dirFiles = rdir.GetFiles("*", SearchOption.AllDirectories);
        foreach (var aFile in dirFiles)
        {
            if (!isMatched)
            {
                if (aFile.Name.Equals("MCRInstaller.exe"))
                {
                    match = aFile.FullName;
                    isMatched = true;
                    break;
                }
            }
            else
            {
                break;
            }
        }
    }
    //match now contains the full path to your installer
