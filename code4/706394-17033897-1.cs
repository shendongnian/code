    public static string RootFilePath = @"C:\path\to\files";
    public FileInfo FileImage { get; set; }
    foreach (var imagetype in Files)
    {
        FileImage = new FileInfo(Path.Combine(RootFilePath, imagetype.FileName));
    }
