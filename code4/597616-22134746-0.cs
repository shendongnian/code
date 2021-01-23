        public void CopyFolderContents(string sourceFolder, string destinationFolder)
        {
            var exDir = sourceFolder;
            var dir = new DirectoryInfo(exDir);
            foreach (string sourceFile in Directory.GetFiles(dir.ToString(), "*.*", SearchOption.TopDirectoryOnly))
            {
                FileInfo srcFile = new FileInfo(sourceFile);
                string srcFileName = srcFile.Name;
                FileInfo destFile = new FileInfo(destinationFolder + "\\" + srcFileName);
                if (srcFile.LastWriteTime > destFile.LastWriteTime || !destFile.Exists)
                {
                    File.Copy(srcFile.FullName, destFile.FullName, true);
                }
            }
        }
