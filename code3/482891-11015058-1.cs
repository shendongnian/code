    var blobStorageClient = storageAccount.CreateCloudBlobClient();
    var container = blobStorageClient.GetContainerReference("pdf");
    container.CreateIfNotExist();
    var permissions = container.GetPermissions();
    permissions.PublicAccess = BlobContainerPublicAccessType.Container;
    container.SetPermissions(permissions);
