    static Task<MemoryObject> GetMemoryObjectAsync(AmazonS3 s3, 
        AmazonS3Request request)
    {
        Task<AmazonS3Response> response = Task.Factory.FromAsync(
            s3.BeginGetObject, s3.EndGetObject, request, null);
        // But what goes here?
