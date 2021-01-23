    string imgName = ofd.SafeFileName;
                if (Directory.Exists(path))
                {
    
                    var directory = new DirectoryInfo(path);
                    foreach (FileInfo file in directory.GetFiles())
                    {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                            file.Delete();
                    }
                }
