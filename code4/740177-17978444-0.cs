    private static void OverWrite(string target, string sourcefile)
    {
        //Grab file name
        var strSrcFile = sourcefile.Split(Path.DirectorySeparatorChar).Last();
        //Search current target directory FILES
        List<string> targetfiles = Directory.GetFiles(target).Select(file=>file.Split(Path.DirectorySeparatorChar).Last()).ToList();
        if (targetfiles.Contains(strSrcFile))
        {
            File.Copy(sourcefile, Path.Combine(target, Path.GetFileName(strSrcFile)), true);
        }
        //Recursively search current target directory SUBFOLDERS
        List<string> subfolders = Directory.GetDirectories(target).ToList();
        foreach (var subfolder in subfolders)
        {
            OverWrite(subfolder, sourcefile);
        }
    }
