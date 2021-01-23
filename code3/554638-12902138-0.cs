    CloudBlobClient blobClient = new CloudBlobClient(blobEndpoint, new StorageCredentialsAccountAndKey(accountName, accountKey));
    
    //Get a reference to the container.
    CloudBlobContainer container = blobClient.GetContainerReference("container");
    
    //List blobs and directories in this container
    var blobs = container.ListBlobs();
    
    foreach (var blobItem in blobs)
    {
    	Console.WriteLine(blobItem.Uri);
    }
