    public class Response
    {
        public Coordinates Data { get; set; }
        public Error Error { get; set; }
    }
    public class Error
    {
        public int code { get; set; }
        public string description { get; set; }
    }
    public class Coordinates 
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
