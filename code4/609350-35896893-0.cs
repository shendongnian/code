    public class StorageReport
    {
        public int FileCount { get; set; }
        public int DirectoryCount { get; set; }
        public long TotalBytes { get; set; }
    }
    
    //embdeded in some method
    StorageReport report = new StorageReport() { 
        FileCount = 0,
        DirectoryCount = 0,
        TotalBytes = 0
    };
    
                
    foreach (IListBlobItem blobItem in container.ListBlobs(null, false, BlobListingDetails.None))
    {
        if (blobItem is CloudBlockBlob)
        {
            CloudBlockBlob blob = blobItem as CloudBlockBlob;
            report.FileCount++;
            report.TotalBytes += blob.Properties.Length;
        }
        else if (blobItem is CloudPageBlob)
        {
            CloudPageBlob pageBlob = blobItem as CloudPageBlob;
                            
            report.FileCount++;
            report.TotalBytes += pageBlob.Properties.Length;
        }
        else if (blobItem is CloudBlobDirectory)
        {
            CloudBlobDirectory directory = blobItem as CloudBlobDirectory;
                            
            report.DirectoryCount++;
        }                        
    }
