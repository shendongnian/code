    private void CreateZip(string largeDir, string splitIntoDir, double maxFolderSize)
            {
                int fileNumber = 1;
    
                // We get all the PDFs and idf files at once
                FileInfo[] files = new DirectoryInfo(largeDir).GetFiles("*.pdf");
                FileInfo[] filesPair = new DirectoryInfo(largeDir).GetFiles("*.idf");
               
                List<FileInfo> toAdd = new List<FileInfo>();
    
                // We match on memory the filenames without extension and create an Anonymous object
                // which will contain both files
    
                var pairs = files.Join(filesPair, f => Path.GetFileNameWithoutExtension(f.FullName),
                    idx => Path.GetFileNameWithoutExtension(idx.FullName), (f, idx) => new {Pdf = f, Index = idx});
    
                long currentOutputSize = 0;
                string outputZip = string.Format("{0}{1}{2}_{3}.zip", splitIntoDir, Path.DirectorySeparatorChar, Path.GetFileName(largeDir), fileNumber);
    
                // iterate the pairs that matched the collection
                foreach (var pair in pairs)
                {
                    // Sum the current pair of files
                    currentOutputSize += pair.Pdf.Length + pair.Index.Length;
    
                    if (currentOutputSize < maxFolderSize) 
                    {
                        toAdd.Add(pair.Pdf);
                        toAdd.Add(pair.Index);
                    }
                    else
                    {
                        using (ZipFile zip = new ZipFile(outputZip))
                        { 
                            toAdd.ForEach(f=> zip.AddFile(f.FullName, string.Empty));
                            zip.Save();
                        }
    
                        // We start a new zip
                        toAdd.Clear();
                        fileNumber++;
                        currentOutputSize += pair.Pdf.Length + pair.Index.Length;
                        foutputZip = string.Format("{0}{1}{2}_{3}.zip", splitIntoDir, Path.DirectorySeparatorChar, Path.GetFileName(largeDir), fileNumber);
    
                        // We add the current iteration's files
                        toAdd.Add(pair.Pdf);
                        toAdd.Add(pair.Index);
                    }
                }
            }
