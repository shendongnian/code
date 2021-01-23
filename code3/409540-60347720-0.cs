    public static class FileUploadExtension
    {
        public static void SaveAs(this FileUpload, string destination, bool autoCreateDirectory) { 
        
            if (autoCreateDirectory)
            {
                var destinationDirectory = new DirectoryInfo(Path.GetDirectoryName(destination));
                if (!destinationDirectory.Exists)
                    destinationDirectory.Create();
            }
            file.SaveAs(destination);
        }
    }
 
