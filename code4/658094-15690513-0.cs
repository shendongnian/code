    [Route("/upload/{FileName}", "POST")]
    public class UploadPackage : IRequiresRequestStream
    {
        public System.IO.Stream RequestStream { get; set; }
        public string FileName { get; set; }
    }
