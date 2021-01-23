    var sharedAccessPolicy = new SharedAccessBlobPolicy
    {
      SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-10),
      SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(30),
      Permissions = SharedAccessBlobPermissions.Read
    };
    var sharedAccessSignature = _blockblob.GetSharedAccessSignature(sharedAccessPolicy);
    return _blockblob.Uri.AbsoluteUri + sharedAccessSignature;
