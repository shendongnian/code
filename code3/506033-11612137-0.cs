    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(FolderName);
    int count = dir.GetFiles().Length;
    
    if (count > 1)
    {
        throw new Exception("More than one mark-off file.");
    }
    else
    {
        // Something else
    }
