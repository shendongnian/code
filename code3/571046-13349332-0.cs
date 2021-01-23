    AmazonS3 client;
    
    GetPreSignedUrlRequest request = new GetPreSignedUrlRequest();
    request.WithBucketName(bucketName);
    request.WithKey(objectKey);
    request.Verb = HttpVerb.GET; // Default.
    request.WithExpires(DateTime.Now.AddMinutes(5));
    
    string url = client.GetPreSignedURL(request);
