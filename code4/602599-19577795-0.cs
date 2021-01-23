    public class WebDownload
    {
        public class WebDownloadResult
        {
            public HttpStatusCode StatusCode { get; set; }
            public int StatusCodeNumber { get; set; }
            public bool ErrorOccured { get; set; }
            public string ResultString { get; set; }
        }
        public static void Download(string url, Action<WebDownloadResult> resultAction)
        {
            WebDownloadResult response = new WebDownloadResult();
            try
            {
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                IAsyncResult result = (IAsyncResult)myHttpWebRequest.BeginGetResponse(new AsyncCallback(delegate(IAsyncResult tempResult)
                {
                    HttpWebResponse webResponse = (HttpWebResponse)myHttpWebRequest.EndGetResponse(tempResult);
                    Stream responseStream = webResponse.GetResponseStream();
                    using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        response.ResultString = reader.ReadToEnd();
                        response.StatusCode = webResponse.StatusCode;
                        response.StatusCodeNumber = (int)webResponse.StatusCode;
                        
                        if (resultAction != null) resultAction(response);
                    }
                }), null);
            }
            catch 
            {
                response.ErrorOccured = true;
                if (resultAction != null) resultAction(response);
            }
        }
    }
