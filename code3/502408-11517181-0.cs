    public void CopyFiles(string sourcePath, string destinationPath)
        {
            string[] files = System.IO.Directory.GetFiles(sourcePath);
            Parallel.ForEach(files, file =>
            {
                System.IO.File.Copy(file, System.IO.Path.Combine(destinationPath, System.IO.Path.GetFileName(file)));
            });
        }
