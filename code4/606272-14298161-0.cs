    interface IClientFactory
    {
      IAmazonS3Client CreateAmazonClient();
    }
    
    interface IAmazonS3Client
    {
      PutObjectResponse PutObject(PutObjectRequest request); // I'm guessing here for the signature.
    }
    
    public class AmazonS3Service : IAmazonS3Service
    {
        // snip
        private IClientFactory factory;
    
        public AmazonS3Service(IClientFactory factory)
        {
           // snip
          this.factory = factory;
        }
    
       public Image UploadImage(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException("stream");
            var key = string.Format("{0}.jpg", Guid.NewGuid());
    
            var request = new PutObjectRequest
            {
                CannedACL = S3CannedACL.PublicRead,
                Timeout = -1,
                ReadWriteTimeout = 600000, // 10 minutes * 60 seconds * 1000 milliseconds
                InputStream = stream,
                BucketName = imageBucket,
                Key = key
            };
    
            // call the factory to provide us with a client.
            using (var client = factory.CreateAmazonClient())
            {
                using (client.PutObject(request))
                {
                }
            }
    
            return new Image
            {
                UriString = Path.Combine(baseImageUrl.AbsoluteUri, key)
            };
        }
    }
