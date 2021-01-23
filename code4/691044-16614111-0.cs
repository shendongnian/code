    List<string> GetFiles(string folder, string filter)
    {
        List<string> files = new List<string>();
        try
        {
            // get all of the files in this directory
            files.AddRange(Directory.GetFiles(folder, filter));
            // Now recursively visit the directories
            foreach (var dir in Directory.GetDirectories(folder))
            {
                files.AddRange(GetFiles(dir, filter));
            }
        }
        catch (UnauthorizedAccessException)
        {
            // problem accessing this directory.
            // ignore it and move on.
        }
        return files;
    }
