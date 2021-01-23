        private CloudBlockBlob GetBlobReference(string filePath, bool createContainerIfMissing = true)
        {
            CloudBlobClient client = _account.CreateCloudBlobClient();
            CloudBlobContainer container = client.GetContainerReference("my-container");
            if ( createContainerIfMissing && container.CreateIfNotExists())
            {
                //Public blobs allow for public access to the image via the URI
                //But first, make sure the blob exists
                container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }
            CloudBlockBlob blob = container.GetBlockBlobReference(filePath);
            return blob;
        }
        public bool Exists(String filepath)
        {
            var blob = GetBlobReference(filepath, false);
            return blob.Exists();
        }
