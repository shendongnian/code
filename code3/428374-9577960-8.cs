    private IEnumerable<FileInfo> GetFileList(string pattern,string Location)
    {
        string directory = string.Empty;
        switch (Location)
        {
            case "SVR01":
                directory = @"\\SVR01\Dev";
            break;
            case "SVR02":
                directory = @"\\SVR02\Dev";
            break;
            case "SVR03":
                directory = @"\\SVR03\Prod");
            break;
            default: 
                throw new ArgumentOutOfRangeException();
        }
        
        DirectoryInfo di = null;
        try
        {
            di = new DirectoryInfo(directory);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            yield break;
        }
        
        foreach(var fi in di.EnumerateFiles(pattern))
            yield return fi;
    }
