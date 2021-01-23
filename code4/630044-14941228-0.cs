    private string[] GetFiles(string directory, string pattern)
    {
        try
        {
            return Directory.GetFiles(directory, pattern, 
                                           SearchOption.AllDirectories);
        }
        catch (Exception)
        {
            return new string[0];
        }
    }
