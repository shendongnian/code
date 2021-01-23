    public class Bytes
    {
        public Bytes(byte[] value, string type)
        {
            Value = value;
            Type = type;
        }
        public byte[] Value { get; private set; }
        public string Type { get; private set; }
    }
    public class FactoryWithContent : IHttpFactory
    {
        public IHttp Create()
        {
            var http = new Http();
            var getBytes = GetBytes;
            if (getBytes != null)
            {
                var bs = getBytes();
                http.RequestBodyBytes = bs.Value;
                http.RequestContentType = bs.Type;
            }
            return http;
        }
        public Func<Bytes> GetBytes { get; set; }
    }
