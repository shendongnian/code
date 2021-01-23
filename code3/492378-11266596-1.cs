    public interface IResponseData
    {
        // whatever
    }
    public class Response<T> where T : IResponseData
    {
        public T Value { get; set; }
    }
