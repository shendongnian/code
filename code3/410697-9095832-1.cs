    public class MyDataRetriever : IDataRetriever
    {
        private readonly string _url;
        public MyDataRetriever(string url)
        {
            _url = url;
        }
        public byte[] RetrieveData(byte[] request)
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "text/plain; charset=utf-8";
                return client.UploadData(_url, request);
            }
        }
    }
