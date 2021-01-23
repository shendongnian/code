    var pathToMyBlob = "/path/1356/pic.jpg";
    var blob = container.GetBlockBlobReference(pathToMyBlob.TrimStart('/'));
    
    var expires = DateTime.UtcNow.AddMinutes(30);
    var sas = blob.GetSharedAccessSignature(new Microsoft.WindowsAzure.Storage.Blob.SharedAccessBlobPolicy
    {
        Permissions = Microsoft.WindowsAzure.Storage.Blob.SharedAccessBlobPermissions.Read,
        SharedAccessExpiryTime = expires
    });
