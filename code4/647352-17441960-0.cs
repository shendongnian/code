    // Begin method
    client.BeginPutObject(request, CallbackWithClient, client);
    
    // Callback
    public static void CallbackWithClient(IAsyncResult asyncResult)
    {
      AmazonS3Client s3Client = (AmazonS3Client) asyncResult.AsyncState;
      PutObjectResponse response = s3Client.EndPutObject(asyncResult);
    
      // Process the response
    }
