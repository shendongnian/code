    private string UploadFileToBlob(string file)
    {
        // Retrieve storage account from connection string
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
    
        // Create the blob client
        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
    
        // Retrieve reference to a previously created container
        CloudBlobContainer container = blobClient.GetContainerReference("mydeployments");
    
        // Retrieve reference to a blob
        var date = DateTime.UtcNow.ToString("yyyyMMdd-hhmmss-");
        var fileinfo = new FileInfo(file);
        if (fileinfo.Exists)
        {
            var fileToUpload = new FileInfo(file).Name;
            var filename = date + fileToUpload;
            try
            {
                CloudBlob blob = container.GetBlobReference(filename);
    
                // Create or overwrite the blob with contents from a local file
                using (var fileStream = System.IO.File.OpenRead(file))
                {
                    blob.UploadFromStream(fileStream);
                }
    
                return blob.Uri.AbsoluteUri;
            }
            catch (Exception ex)
            {
                LogError("Error uploading file to blog: ", ex.Message);
                return "";
            }
        }
    
        LogError("Error - specified file does not exist: ", file);
        return "";
    }
