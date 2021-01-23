    AmazonS3Client client = new AmazonS3Client();
    CopyObjectRequest request = new CopyObjectRequest {
          SourceBucket = "fromBucket",
          SourceKey = "fromFile",
          DestinationBucket = "toBucket",
          DestinationKey = "toFilename",
          CannedACL = S3CannedACL.BucketOwnerFullControl
     };
     CopyObjectResponse response = client.CopyObject(request);
