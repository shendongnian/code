    public class Response<T> where T : new() {
        public T Data { get; set; }
        public ErrorsManager Error { get; set; }
        public Response() {
            Error = new ErrorsManager();
            Data = new T();
        }
    }
    public class Coordinates {
        /* left away */
    }
