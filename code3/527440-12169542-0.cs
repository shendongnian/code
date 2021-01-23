    static void Main(string[] args)
    {
        string backupPath = @"C:\Backup\";
        string[] folders = Directory.GetDirectories(backupPath);
        Int16 max = 0;
        foreach (var item in folders)
        {
            //int lastPartOfFolderName;
            int lastDotPosition = item.LastIndexOf('.');
            Int16 folderNumber;
            if (Int16.TryParse(item.Substring(lastDotPosition + 1), out folderNumber))
            {
                if (folderNumber > max)
                {
                    max = folderNumber;
                }
            }
        }
        max++;                
        Directory.CreateDirectory(@"C:\Backup\Data." + max);
    }
