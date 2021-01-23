    static Task<MemoryStream> GetMemoryStreamAsync(AmazonS3 s3, 
        GetObjectRequest request)
    {
        // Start the task of downloading.
        Task<GetObjectResponse> response = 
            Task.Factory.FromAsync<GetObjectRequest,GetObjectResponse>(
                s3.BeginGetObject, s3.EndGetObject, request, null
            );
        // Translate.
        Task<MemoryStream> translation = response.ContinueWith(t => {
            using (Task<GetObjectResponse> resp = t ){
                var ms = new MemoryStream(); 
                t.Result.ResponseStream.CopyTo(ms); 
                return ms;
            } 
        });
        // Return the full task chain.
        return translation;
    }
