    public FileInfo FileImage { get; set; }
    foreach (var imagetype in Files)
    {
        FileImage = new FileInfo(imagetype.FileName);
    }
