    private static void AddFilesFromDirectoryToDictionary(Dictionary<string, string> filesDictionary,
      string pathToDirectory)
    {      
      DirectoryInfo dirInfo = new DirectoryInfo(pathToDirectory);      
      FileInfo[] fileInfos = dirInfo.GetFiles("*.*", SearchOption.AllDirectories);
      foreach (FileInfo fi in fileInfos)
      {        
        filesDictionary.Add(fi.FullName.Replace(dirInfo.Parent.FullName, ""),
          fi.FullName);
      }        
    }
    
    static void Main(string[] args)
    {
      // Set path to 7z library.
      SevenZipCompressor.SetLibraryPath("7z.dll");
      using (FileStream fs = new FileStream("c:\\temp\\test.7z", FileMode.Create))
      {        
        SevenZipCompressor szc = new SevenZipCompressor
                                     {
                                       CompressionMethod = CompressionMethod.Lzma,
                                       CompressionLevel = CompressionLevel.Normal,
                                       CompressionMode = CompressionMode.Create,                                      
                                       DirectoryStructure = true,
                                       PreserveDirectoryRoot = false,
                                       ArchiveFormat = OutArchiveFormat.SevenZip
                                     };        
        Dictionary<string, string> filesDictionary = new Dictionary<string, string>();
        AddFilesFromDirectoryToDictionary(filesDictionary, @"c:\temp\testdir1");
        AddFilesFromDirectoryToDictionary(filesDictionary, @"c:\temp\testdir2");
        AddFilesFromDirectoryToDictionary(filesDictionary, @"c:\temp2\test");
        
        szc.CompressFileDictionary(filesDictionary, fs);                               
      }      
    }
