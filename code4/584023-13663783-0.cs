    public class Response
    {
        public object Data { get; set; }
        public object Error { get; set; }
        public Response()
        {
            Error = new ErrorsManager();
            Data = new Coordinates();
        }
    }
    public class Coordinates {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
