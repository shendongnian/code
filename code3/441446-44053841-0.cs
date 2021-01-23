    using (var s3Client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1))
    {
        ListObjectsV2Request request = new ListObjectsV2Request
        {
              BucketName = bucketName,
              MaxKeys = 10
        };
        ListObjectsV2Response response;
        do
        {
             response = await s3Client.ListObjectsV2Async(request);
             // Process response.
             // ...
             request.ContinuationToken = response.NextContinuationToken;
        } while (response.IsTruncated == true);        
    }
