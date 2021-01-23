    private struct HttpPostParam
    {
        private string _key;
        private string _value;
        public string Key { get { return HttpUtility.UrlEncode(this._key); } set { this._key = value; } }
        public string Value { get { return HttpUtility.UrlEncode(this._value); } set { this._value = value; } }
        public HttpPostParam(string key, string value)
        {
            this._key = key;
            this._value = value;
        }
    };
    private static string PostTrivialData(Uri page, HttpPostParam[] parameters)
    {
        string pageResponse = string.Empty;
        try
        {
            var request = (HttpWebRequest)WebRequest.Create(page); //create the initial request.
            request.Method = WebRequestMethods.Http.Post; //set the method
            request.AllowAutoRedirect = true; //couple of settings I personally prefer.
            request.KeepAlive = true;
            request.ContentType = "application/x-www-form-urlencoded";
            //create the post data.
            byte[] bData = Encoding.UTF8.GetBytes(string.Join("&", Array.ConvertAll(parameters, kvp => string.Format("{0}={1}", kvp.Key, kvp.Value))));
            using (var reqStream = request.GetRequestStream())
                reqStream.Write(bData, 0, bData.Length); //write the data to the request.
            using (var response = (HttpWebResponse)request.GetResponse()) //attempt to get the response.
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NotModified) //check for a valid status (should only return 200 if successful)
                    using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                        pageResponse = reader.ReadToEnd();
        }
        catch (Exception e)
        {
            /* todo: any error handling, for my use case failing gracefully was all that was needed. */
        }
        return pageResponse;
    }
