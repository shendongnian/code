    public void DisposeAfterTest(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Directory.Exists(this.TempTestFolderPath))
            {
                Directory.Delete(this.TempTestFolderPath, true);
            }
        }
