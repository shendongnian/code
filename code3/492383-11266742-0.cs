    public class Response
    {
        public object Value
        {
            get;
            set;
        }
    }
    public class Response<T> : Response
    {
        public T Value
        {
            get;
            set;
        }
    }
