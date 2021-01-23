    public static long GetSpaceUsed(string containerName)
    {
        var container = CloudStorageAccount
            .Parse(ConfigurationManager.ConnectionStrings["StorageConnection"].ConnectionString)
            .CreateCloudBlobClient()
            .GetContainerReference(containerName);
        if (container.Exists())
        {
            return (from CloudBlockBlob blob in
                    container.ListBlobs(useFlatBlobListing: true)
                    select blob.Properties.Length
                   ).Sum();
        }
        return 0;
    }
