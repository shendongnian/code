    class FileData
    {
        string FileName { get; set; }
        string Contents { get; set; }
    }
    
    var fileContents = from file in fileNames
                       select new FileData
                       {
                           FileName = Path.GetExtension(file),
                           Contents = File.ReadAllText(file)
                       }; 
