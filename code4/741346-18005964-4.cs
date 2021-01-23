    public class ServerResponse
    {
        public string Content { get; set; }
        public HttpStatusCode Status { get; set; } // enum
        // use this in first method to check if request succeed
        public bool IsError
        {
           get { return (int)Status > 399; }
        }
    }
