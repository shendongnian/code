            CloudStorageAccount storageAccount = CloudStorageAccount.DevelopmentStorageAccount;
            CloudBlobContainer blobContainer = storageAccount.CreateCloudBlobClient().GetContainerReference("images");
            var blobs = blobContainer.ListBlobs(new BlobRequestOptions()
                {
                    BlobListingDetails = BlobListingDetails.All,
                    UseFlatBlobListing = true,
                }).Cast<CloudBlockBlob>();
            foreach (var blockBlob in blobs)
            {
                Console.WriteLine("Name: " + blockBlob.Name);
                Console.WriteLine("Size: " + blockBlob.Properties.Length);
                Console.WriteLine("Content type: " + blockBlob.Properties.ContentType);
                Console.WriteLine("Download location: " + blockBlob.Uri);
                Console.WriteLine("=======================================");
            }
