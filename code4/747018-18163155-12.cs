    using (FileStream fs = new FileStream("c:\\temp\\test.zip", FileMode.Create))
    {        
      SevenZipCompressor szc = new SevenZipCompressor
              {
                CompressionMethod = CompressionMethod.Deflate,
                CompressionLevel = CompressionLevel.Normal,
                CompressionMode = CompressionMode.Create,                                      
                DirectoryStructure = true,
                PreserveDirectoryRoot = false,
                ArchiveFormat = OutArchiveFormat.Zip
              };        
       Dictionary<string, string> filesDictionary = new Dictionary<string, string>();
       AddFilesFromDirectoryToDictionary(filesDictionary, @"c:\temp\testdir1");
       AddFilesFromDirectoryToDictionary(filesDictionary, @"c:\temp\testdir2");
       AddFilesFromDirectoryToDictionary(filesDictionary, @"c:\temp2\test");
        
       szc.CompressFileDictionary(filesDictionary, fs);                               
     }
    
