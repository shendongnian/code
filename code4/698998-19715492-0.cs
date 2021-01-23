    public class S3MultipartUpload : IDisposable
    {
        string accessKey = System.Configuration.ConfigurationManager.AppSettings.Get("AWSAccessKey");
        string secretAccessKey = System.Configuration.ConfigurationManager.AppSettings.Get("AWSSecretKey");
        AmazonS3 client;
        public string OriginalFilename { get; set; }
        public string DestinationFilename { get; set; }
        public string DestinationBucket { get; set; }
        public InitiateMultipartUploadResponse initResponse;
        public List<PartETag> uploadPartETags;
        public string UploadId { get; private set; }
        public S3MultipartUpload(string destinationFilename, string destinationBucket)
        {
            if (client == null)
            {
                System.Net.WebRequest.DefaultWebProxy = null; // disable proxy to make upload quicker
                client = Amazon.AWSClientFactory.CreateAmazonS3Client(accessKey, secretAccessKey, new AmazonS3Config()
                {
                    RegionEndpoint = Amazon.RegionEndpoint.EUWest1,
                    CommunicationProtocol = Protocol.HTTP
                });
                this.OriginalFilename = destinationFilename.TrimStart('/');
                this.DestinationFilename = string.Format("{0:yyyy}{0:MM}{0:dd}{0:HH}{0:mm}{0:ss}{0:fffff}_{1}", DateTime.UtcNow, this.OriginalFilename);
                this.DestinationBucket = destinationBucket;
                this.InitializePartToCloud();
            }
        }
        private void InitializePartToCloud()
        {
            // 1. Initialize.
            uploadPartETags = new List<PartETag>();
            InitiateMultipartUploadRequest initRequest = new InitiateMultipartUploadRequest();
            initRequest.BucketName = this.DestinationBucket;
            initRequest.Key = this.DestinationFilename;
            // make it public
            initRequest.AddHeader("x-amz-acl", "public-read");
            initResponse = client.InitiateMultipartUpload(initRequest);
        }
        public void UploadPartToCloud(Stream fileStream, long uploadedBytes, long maxChunkedBytes)
        {
            int partNumber = uploadPartETags.Count() + 1; // current part
            // 2. Upload Parts.
            UploadPartRequest request = new UploadPartRequest();
            request.BucketName = this.DestinationBucket;
            request.Key = this.DestinationFilename;
            request.UploadId = initResponse.UploadId;
            request.PartNumber = partNumber;
            request.PartSize = fileStream.Length;
            //request.FilePosition = uploadedBytes // remove this line?
            request.InputStream = fileStream; // as UploadPartRequest;
            var up = client.UploadPart(request);
            uploadPartETags.Add(new PartETag() { ETag = up.ETag, PartNumber = partNumber });
        }
        public string CompletePartToCloud()
        {
            // Step 3: complete.
            CompleteMultipartUploadRequest compRequest = new CompleteMultipartUploadRequest();
            compRequest.BucketName = this.DestinationBucket;
            compRequest.Key = this.DestinationFilename;
            compRequest.UploadId = initResponse.UploadId;
            compRequest.PartETags = uploadPartETags;
            string r = "Something went badly wrong";
            using (CompleteMultipartUploadResponse completeUploadResponse = client.CompleteMultipartUpload(compRequest))
                r = completeUploadResponse.ResponseXml;
            return r;
        }
        public void AbortPartToCloud()
        {
            // abort.
            client.AbortMultipartUpload(new AbortMultipartUploadRequest()
            {
                BucketName = this.DestinationBucket,
                Key = this.DestinationFilename,
                UploadId = initResponse.UploadId
            });
        }
        public void Dispose()
        {
            if (client != null) client.Dispose();
            if (initResponse != null) initResponse.Dispose();
        }
    }
