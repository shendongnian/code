    public class MetadataResponse
    {
        public Response Response { get; set; }
    }
    public class Response
    {
        public string MetadataA { get; set; }
        public string MetadataB { get; set; }
        public string MetadataC { get; set; }
        public string MetadataZ { get; set; }
        public List<Result> Results { get; set; }
    }
    public class Result
    {
        public string ResultmetadataA { get; set; }
        public string ResultmetadataB { get; set; }
        public string ResultId { get; set; }
        public string ResultName { get; set; }
    }
