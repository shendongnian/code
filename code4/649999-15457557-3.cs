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
        try
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
        catch (UnauthorizedAccessException err)
        {
            using (StreamWriter errLog = File.AppendText("errors.log"))
            {
                string dt = "[" + DateTime.Now + "]: ";
                errLog.Write(dt);
                errLog.Write(err.StackTrace);
            }
        }
    }
    foreach (string match in matches)
    {
        //do some stuff with your list of matches
    }
