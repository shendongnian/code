    string[] subDirs = 
                System.IO.Directory.GetDirectories(SourcePath, "*",
                (System.IO.SearchOption.AllDirectories));
                    int subFiles = System.IO.Directory.GetFiles(SourcePath, "*.*",
             SearchOption.AllDirectories).Length;
     progressBar1.Maximum = subFiles+(subDirs.Length);
     progressBar1.Value = 0;
     foreach (string dirPath in Directory.GetDirectories(SourcePath, "*",
           SearchOption.AllDirectories))
     {
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
