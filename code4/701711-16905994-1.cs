    public void MyMain()
    {
        string path = "Some Directory/Some SubDirectory/SomeFile.pdf";
        string fileName = GetFileNameFromPath(path);
    }
    private static string ReverseString(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
    public static string GetFileNameFromPath(string path)
    {
        string fileName = string.Empty;
        path = path.ReverseString();
        fileName = path.Substring(0, path.IndexOf(@"\")).ReverseString();
        return fileName;
    }
