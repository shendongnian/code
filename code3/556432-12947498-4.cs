    public static bool IsValidPath(string path)
    {
        try
        {
           path = path.Replace(@"\\", ":"); // to cancel out c:\\\\test.text
           string temp = Path.GetPathRoot(path); //For cases like: \text.txt
           if (temp.StartsWith(@"\"))
                return false;
           string pt = Path.GetFullPath(path);
        }
        catch //(Exception NotSupportedException) // catch specific exception here or not if you want
        {
            return false;
        }
        return true;
    }
