    public class AzureStorageService
    {
        readonly CloudStorageAccount _storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
        public void RenameBlob(string oldName, string newName)
        {
            var blobClient = _storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("MyContainer");
            var blobs = container.GetDirectoryReference(oldName.ToLower()).ListBlobs();
            foreach (var item in blobs)
            {
                string blobUri = item.Uri.ToString();
                var oldBlob = container.GetBlockBlobReference(blobUri.ToLower());
                var newBlob = container.GetBlockBlobReference(blobUri.Replace(oldName, newName).ToLower());
                newBlob.StartCopyFromBlob(oldBlob);
               oldBlob.Delete();
            }
        }
    }
