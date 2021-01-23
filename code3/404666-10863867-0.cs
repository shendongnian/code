    var request = new ListObjectsRequest()
    .WithBucketName("bucketname")
    .WithPrefix(@"folder1/")
    .WithDelimiter(@"/");
    using (var client = Amazon.AWSClientFactory.CreateAmazonS3Client(accessKey, secretKey))
    using (var response = client.ListObjects(request))
    {
        foreach (var subFolder in response.CommonPrefixes)
        {
            /* list the sub-folders */
        }
        foreach (var file in response.S3Objects) {
             /* list the files */
        }
    }
