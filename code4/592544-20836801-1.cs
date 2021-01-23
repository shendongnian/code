    private TransferUtility transferUtility;
    transferUtility = new TransferUtility(awsAccessKey, awsSecretKey);
    
    AsyncCallback callback = new AsyncCallback(UploadComplete);
    
    
    var putObjectRequest = new Amazon.S3.Transfer.TransferUtilityUploadRequest()
    {
       FilePath = filePath,
       BucketName = awsBucketName,
       Key = awsFilePath,
       ContentType = contentType,
       StorageClass = S3StorageClass.ReducedRedundancy,
       ServerSideEncryptionMethod = ServerSideEncryptionMethod.AES256,
       CannedACL = S3CannedACL.Private
    };
    IAsyncResult ar = transferUtility.BeginUpload(putObjectRequest, callback, null);
    ThreadPool.QueueUserWorkItem(c =>
    {
       transferUtility.EndUpload(ar);
    });
