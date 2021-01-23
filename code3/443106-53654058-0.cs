            public void Unpack()
            {
                var rawBytes = File.ReadAllBytes(".\\Some.rar");
             
                using (var stream = new MemoryStream(rawBytes, true))
                {
                    // Toggle between the x86 and x64 bit dll
                    var path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, Environment.Is64BitProcess ? "x64" : "x86", "7z.dll");
                    SevenZip.SevenZipBase.SetLibraryPath(path);
                    using (var outMemStream = File.Create(".\\SomeSingleFile.txt"))
                    {
                        var extractor = new SevenZipExtractor(stream, "passwordXXX");
                        var entry = extractor.ArchiveFileData.Single(info => false == nfo.IsDirectory);    
                        extractor.ExtractFile(entry.Index, outMemStream);                        
                    }
                }
            }
