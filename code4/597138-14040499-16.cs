    List<FileEntry> files = new  List<FileEntry> ();
    for .......
    {
        files.Add(new FileEntry()
        {
            FileName  = .....,
            FileRelativePath = .....,
            FileContents = File.ReadAllBytes(......),
        };
    }
