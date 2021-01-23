    [TestMethod]
    public void InputStreamSetOnPutObjectRequest()
    {
      var factory = new TestFactory();
      var service = new AmazonS3Service(factory);
      using (var stream = new MemoryStream())
      {
          service.UploadImage(stream);
          Assert.AreEqual(stream, factory.TestClient.Request.InputStream);
      }
    }
    
    class TestFactory : IClientFactory
    {
      public TestClient TestClient = new TestClient();
    
      public IAmazonS3Client CreateClient()
      {
         return TestClient;
      }
    }
    
    class TestClient : IAmazonS3Client
    {
      public PutObjectRequest Request;
      public PutObjectResponse Response;
    
      public PutObjectResponse PutObject(PutObjectRequest request)
      {
        Request = request;
        return Response;
      }
    }
