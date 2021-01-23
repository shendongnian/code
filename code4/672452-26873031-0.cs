	string filename = "nameoffiletocopy"
	using (Stream stream = GetS3Stream(filename))
	{
		AmazonS3Config config = new AmazonS3Config 
			{CommunicationProtocol = Protocol.HTTP};
		AmazonS3 client = 
			AWSClientFactory.CreateAmazonS3Client(
				"destinationaccesskey",
				"destinationsecretacceskey", 
				config);
		string destinationBucketName = "destinationbucketname";
		PutObjectRequest request = new PutObjectRequest
		{
			BucketName = destinationBucketName,
			InputStream = stream,
			Key = filename,
			CannedACL = S3CannedACL.PublicRead
		};
		PutObjectResponse response = client.PutObject(request);		
	}
	private static Stream GetS3Stream(string filename)
	{
		AmazonS3Config config = new AmazonS3Config 
			{CommunicationProtocol = Protocol.HTTP};
		AmazonS3 client = AWSClientFactory.CreateAmazonS3Client(
			"sourceaccesskey",
			"sourcesecretacceskey", 
			config);
		string sourceBucketName = "sourcebucketname";
		GetObjectRequest request = new GetObjectRequest 
			{
				BucketName = sourceBucketName, 
				Key = filename
			};
		using (GetObjectResponse response = client.GetObject(request))
		{
			byte[] binaryData = 
			ReadFully(response.ResponseStream, -1);
			//ReadyFully from Jon Skeet's blog
			return new MemoryStream(binaryData);
		}
	}
