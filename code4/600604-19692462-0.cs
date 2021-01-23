    [Route("/filestorage/outgoing/{Name}.{Extension}", "GET")]
    [Route("/filestorage/outgoing", "GET")]
    public class GetFileStorageStream : IReturn<HttpResult>
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public bool ForDownload { get; set; }
    }
