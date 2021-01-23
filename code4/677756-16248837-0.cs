    foreach (string dirPath in Directory.GetDirectories(StartDirectory, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dirPath.Replace(StartDirectory, EndDirectory));
                    foreach (string filename in Directory.EnumerateFiles(dirPath))
                    {
                        using (FileStream SourceStream = File.Open(filename, FileMode.Open))
                        {
                            using (FileStream DestinationStream = File.Create(filename.Replace(StartDirectory, EndDirectory)))
                            {
                               
                                await SourceStream.CopyToAsync(DestinationStream);
                            }
                        }
                    }
                }
    
                foreach (string filename in Directory.EnumerateFiles(StartDirectory))
                {
                    using (FileStream SourceStream = File.Open(filename, FileMode.Open))
                    {
                        using (FileStream DestinationStream = File.Create(EndDirectory + filename.Substring(filename.LastIndexOf('\\'))))
                        {
                         
                            await SourceStream.CopyToAsync(DestinationStream);
                        }
                    }
                }
