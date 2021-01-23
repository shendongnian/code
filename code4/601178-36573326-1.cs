    targetCloudBlob.StartCopy(sourceCloudBlob.Uri);
    or
    targetCloudBlob.StartCopyAsync(sourceCloudBlob.Uri);
    while (targetCloudBlob.CopyState.Status == CopyStatus.Pending)
    {
        Thread.Sleep(500);
    }
    if (targetCloudBlob.CopyState.Status != CopyStatus.Success)
    {
        throw new Exception("Copy failed: " +    targetCloudBlob.CopyState.Status);
    }
