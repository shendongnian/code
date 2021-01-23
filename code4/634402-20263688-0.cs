        private static void ReadS3Object(AmazonS3Client client)
        {
            GetObjectRequest request = new GetObjectRequest();
            request.WithBucketName(BUCKET_NAME);
            request.WithKey(S3_KEY);
            GetObjectResponse response = client.GetObject(request);
            StreamReader reader = new StreamReader(response.ResponseStream);
            String content = reader.ReadToEnd();
            Console.Out.WriteLine("Read S3 object with key " + S3_KEY + " in bucket " + BUCKET_NAME + ". Content is: " + content);
        }
