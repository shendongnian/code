    private double CalculateSize(string sourcePath, Progress state, List<FileInfo> filesToCopy)
        {
            int _fileCount = 0;
            DirectoryInfo sourceDirectory = new DirectoryInfo(sourcePath);
            FileInfo[] files = null;
            try
            {
                files = sourceDirectory.GetFiles();
            }
            catch(UnauthorizedAccessException ex)
            { 
                // DO SOME LOGGING-MAGIC IN HERE...
            }
            if (files != null)
            {
                foreach (FileInfo file in files)
                {
                    fullSizeToCopy += file.Length;
                    filesToCopy.Add(file);
                    _fileCount++;
                }
            }
            DirectoryInfo[] directories = null;
            try
            {
                directories = sourceDirectory.GetDirectories();
            }
            catch(UnauthorizedAccessException ex)
            {
                // Do more logging Magic in here...
            }
            if (directories != null)
            foreach (DirectoryInfo direcotry in directories)
            {
                CalculateSize(direcotry.FullName, state, filesToCopy);
            }
            state.FileCount = _fileCount;
            return fullSizeToCopy;
        }
