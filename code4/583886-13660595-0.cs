    class APIRequest : WebClient
    {
        public Uri Url { get; private set; }
        public NameValueCollection Data { get; private set; }
        public void sendRequest(Uri url, NameValueCollection data)
        {
            Url = url;
            Data = data;
            Headers["Content-Type"] = "application/x-www-form-urlencoded";
            UploadValuesAsync(url, "POST", data);
        }
    }
