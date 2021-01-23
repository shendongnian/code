    public void SendFolder(string srcPath, string destPath)
        {
            string dirName = Path.Combine(destPath, Path.GetFileName(srcPath));
            CreateDirectory(dirName);  // consider that this method creates a directory at the server
            string[] fileEntries = Directory.GetFiles(srcPath);
            string[] subDirEntries = Directory.GetDirectories(srcPath);
            foreach (string filePath in fileEntries)
            {
                Send(srcPath, dirName);
            }
            foreach (string dirPath in subDirEntries)
            {
                SendFolder(dirPath, dirName);
            }
        }
