            foreach (RarArchiveEntry entry in archive.Entries)
            {
                try
                {
                    string fileName = Path.GetFileName(entry.FilePath);
                    string rootToFile = Path.GetFullPath(entry.FilePath).Replace(fileName, "");
                    if (!Directory.Exists(rootToFile))
                    {
                        Directory.CreateDirectory(rootToFile);
                    }
                    entry.WriteToFile(rootToFile + fileName, ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);
                }
                catch (Exception ex)
                {
                    //handle your exception here..
                }
            }
