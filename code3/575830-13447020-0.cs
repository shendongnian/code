            if (Directory.Exists(sourceFolder))
            {
                var files = Directory.GetFiles(sourceFolder, filter, SearchOption.AllDirectories);
                foreach(string directory in files.Select(f => Path.GetDirectoryName(f)).Distinct())
                {
                    string destinationDirectory = directory.Replace(sourceFolder, destinationFolder);
                    if (!Directory.Exists(destinationDirectory))
                    {
                        Directory.CreateDirectory(destinationDirectory);                        
                    }
                }
                foreach (string sourceFile in files)
                {
                    string destinationFile = sourceFile.Replace(sourceFolder, destinationFolder);
                    File.Copy(sourceFile, destinationFile, true);
                }
            }
