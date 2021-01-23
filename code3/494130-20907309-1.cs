    public class ClientHttpResponseMessage : IODataResponseMessage
    {
        private readonly HttpWebResponse webResponse;
        public ClientHttpResponseMessage(HttpWebResponse webResponse)
        {
            if (webResponse == null)
                throw new ArgumentNullException("webResponse");
            this.webResponse = webResponse;
        }
        public IEnumerable<KeyValuePair<string, string>> Headers
        {
            get
            {
                return this.webResponse.Headers.AllKeys.Select(
                    headerName => new KeyValuePair<string, string>(
                       headerName, this.webResponse.Headers.Get(headerName)));
            }
        }
        public int StatusCode
        {
            get { return (int)this.webResponse.StatusCode; }
            set
            {
                throw new InvalidOperationException(
                    "The HTTP response is read-only, status code can't be modified on it.");
            }
        }
        public Stream GetStream()
        {
            return this.webResponse.GetResponseStream();
        }
        public string GetHeader(string headerName)
        {
            if (headerName == null)
                throw new ArgumentNullException("headerName");
            return this.webResponse.Headers.Get(headerName);
        }
        public void SetHeader(string headerName, string headerValue)
        {
            throw new InvalidOperationException(
                "The HTTP response is read-only, headers can't be modified on it.");
        }
    }
