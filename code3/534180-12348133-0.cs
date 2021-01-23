     public class FileNameFixer
        {
            public FileNameFixer()
            {
                StringToRemove = "_";
                StringReplacement = "";
    
    
            }
            public void FixAll(string directory)
            {
                IEnumerable<string> files = Directory.EnumerateFiles(directory);
                foreach (string file in files)
                {
                    try
                    {
                        FileInfo info = new FileInfo(file);
                        if (!info.IsReadOnly && !info.Attributes.HasFlag(FileAttributes.System))
                        {
                            string destFileName = GetNewFile(file);
                            info.MoveTo(destFileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.Write(ex.Message);
                    }
                }
            }
    
            private string GetNewFile(string file)
            {
                string nameWithoutExtension = Path.GetFileNameWithoutExtension(file);
                if (nameWithoutExtension != null && nameWithoutExtension.Length > 1)
                {
                    return Path.Combine(Path.GetDirectoryName(file),
                        file.Replace(StringToRemove, StringReplacement) + Path.GetExtension(file));
                }
                return file;
            }
    
            public string StringToRemove { get; set; }
    
            public string StringReplacement { get; set; }
        }
