    public class Response
    {
        public Coordinates Data { get; set; }
        public ErrorsManager Error { get; set; }
        public Response()
        {
            Error = new ErrorsManager();
            Data = new Coordinates();
        }
    }
