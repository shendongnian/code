    public void UploadFile(RemoteFileInfo request)
    {
        config = new AmazonS3Config();
        config.CommunicationProtocol = Protocol.HTTP;
        accessKeyID = "XXXXXXX"; 
        secretAccessKeyID = "YYYYYYYY";
        client = Amazon.AWSClientFactory.CreateAmazonS3Client(accessKeyID,secretAccessKeyID,config);
        
        int chunkSize = 2048;
        byte[] buffer = new byte[chunkSize];
        
        PutObjectRequest fileRequest = new PutObjectRequest();
        
        fileRequest.Key = "testfile.pdf";
        fileRequest.WithBucketName("tempbucket");
        fileRequest.CannedACL = S3CannedACL.Private;
        fileRequest.StorageClass = S3StorageClass.Standard;
        
        using (fileRequest.InputStream = new System.IO.MemoryStream())
        {
          do
          {
             // read bytes from input stream
             int bytesRead = request.FileByteStream.Read(buffer, 0, chunkSize);
             if (bytesRead == 0) break;
        
             // simulates slow connection
             System.Threading.Thread.Sleep(3);
        
             // write bytes to output stream
             fileRequest.InputStream.Write(buffer, 0, bytesRead);
           } while (true);
        
           // report end
           Console.WriteLine("Done!");
                    
           client.PutObject(fileRequest);
               
        }
     }
