    [CompilerGenerated]
    internal class ClosureImplementation
    {
        public AmazonS3 s3Client;
    
        public void Method(object s, EventArgs args)
        {
            s3Client.PutObject(titledRequest);
        }
    }
