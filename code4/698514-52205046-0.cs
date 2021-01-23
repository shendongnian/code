    string tempPath = Path.GetTempPath() + "\\mysubfolder";
    Directory.CreateDirectory(tempPath);
    var parameters = new CompilerParameters(includeAssemblies.ToArray())
                    {                    
                        GenerateInMemory = true,
                        TempFiles = new TempFileCollection(tempPath)
                    };
