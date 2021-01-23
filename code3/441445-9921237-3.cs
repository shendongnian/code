    static AmazonS3 client;
    client = Amazon.AWSClientFactory.CreateAmazonS3Client(
                        accessKeyID, secretAccessKeyID);
                    
    ListObjectsRequest request = new ListObjectsRequest();
    request.BucketName = bucketName;
    do
    {
       ListObjectsResponse response = client.ListObjects(request);
    
       // Process response.
       // ...
    
       // If response is truncated, set the marker to get the next 
       // set of keys.
       if (response.IsTruncated)
       {
            request.Marker = response.NextMarker;
       }
       else
       {
            request = null;
       }
    } while (request != null);
