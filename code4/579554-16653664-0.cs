    public void UploadFile(string filePath, string toPath)
    {
        try
        {
            AsyncCallback callback = new AsyncCallback(uploadComplete);
            log.Info("S3 upload started...");
            log.InfoFormat("S3 filePath: {0}", filePath);
            log.InfoFormat("S3 toPath: {0}", toPath);
            var uploadRequest = new Amazon.S3.Transfer.TransferUtilityUploadRequest();
            uploadRequest.FilePath = filePath;
            uploadRequest.BucketName = bucketName;
            uploadRequest.Key = toPath;
            uploadRequest.StorageClass = Amazon.S3.Model.S3StorageClass.ReducedRedundancy;
            uploadRequest.AddHeader("x-amz-acl", "public-read");
            IAsyncResult ar = transferUtility.BeginUpload(uploadRequest, callback, null);
            // transferUtility.EndUpload(ar);
            ThreadPool.QueueUserWorkItem(c =>
            {
                 try
                 {
                     transferUtility.EndUpload(ar);
                 }
                 catch (AmazonS3Exception ex)
                 {
                     // Retry, log the error, etc.
                 }
                 catch (WebException ex)
                 {
                     // Retry, log the error, etc.
                 }
             });
        }
        catch (AmazonS3Exception amazonS3Exception)
        {
              log.ErrorFormat("An Error, number {0}, occurred when creating a bucket with the message '{1}", amazonS3Exception.ErrorCode, amazonS3Exception.Message);
        }
    }
