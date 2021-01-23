    static Task<MemoryObject> GetMemoryObjectAsync(AmazonS3 s3, 
        AmazonS3Request request)
    {
        // Start the task of downloading.
        Task<AmazonS3Response> response = Task.Factory.FromAsync(
            s3.BeginGetObject, s3.EndGetObject, request, null);
        // Translate.
        Task<MemoryObject> translation = response.ContinueWith(t => {
            var mo = new MemoryObject(); 
            // t is a Task<AmazonS3Result>
            // NOTE: Do you have to dispose of this?
            t.Result.responseStream.CopyTo(mo); 
            // Return the object.
            return mo; 
        });
        // Return the full task chain.
        return translation;
    }
