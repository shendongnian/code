    private void StartRenaming(string FolderName)
    {
        string[] files = Directory.GetFiles(FolderName);
        string[] applicableFiles = (from string s in files
                                    where Regex.IsMatch(s, @"(\d+)|(-+)", RegexOptions.None)
                                    select s).ToArray<string>();
    
        foreach (string file in applicableFiles)
            RenameFile(file);
    }
    
    private void RenameFile(string file)
    {
        string newFileName = file.Replace(@"(\d+)|(-+)", "");
        File.Move(file, Path.Combine(Path.GetDirectoryName(file), newFileName));
    }
