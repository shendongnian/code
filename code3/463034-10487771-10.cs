    static Task<MemoryStream> GetMemoryStreamAsync(AmazonS3 s3, 
        GetObjectRequest request)
    {
        Task<GetObjectResponse> response = 
            Task.Factory.FromAsync<GetObjectRequest,GetObjectResponse>(
                s3.BeginGetObject, s3.EndGetObject, request, null);
        // But what goes here?
