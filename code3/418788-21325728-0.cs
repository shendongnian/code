                    progressBar1.Value++;
                    progressBar1.PerformStep();
                    Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));
                    Application.DoEvents();       
                }
                
                foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                     SearchOption.AllDirectories))
                {
                    progressBar1.Value++;
                    File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
                    Application.DoEvents();
                    
                }
