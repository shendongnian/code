    public static string MakeValidFolderNameSimple(string folderName)
    {
        if (string.IsNullOrEmpty(folderName)) return folderName;
        foreach (var c in System.IO.Path.GetInvalidFileNameChars())
            folderName = folderName.Replace(c.ToString(), string.Empty);
        foreach (var c in System.IO.Path.GetInvalidPathChars())
            folderName = folderName.Replace(c.ToString(), string.Empty);
        return folderName;
    }
