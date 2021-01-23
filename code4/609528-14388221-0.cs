    public static async Task<HttpWebResponse> SendHttpPostRequest(string url, string content, string contentType, string acceptType)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp(new Uri(url, UriKind.Absolute));
            HttpWebResponse response = new HttpWebResponse();
            string responseText = "";
            request.Method = "POST";
            request.ContentType = contentType;
            request.Accept = acceptType;
            Task<Stream> requestTask = Task.Factory.FromAsync(request.BeginGetRequestStream, asyncResult => request.EndGetRequestStream(asyncResult), (object)null);
            await requestTask.ContinueWith(t =>
            {
                using (Stream stream = requestTask.Result)
                using (StreamWriter requestWriter = new StreamWriter(stream))
                {
                    requestWriter.Write(content);
                }
            });
            Task<WebResponse> responseTask = Task.Factory.FromAsync(request.BeginGetResponse, asyncResult => request.EndGetResponse(asyncResult), (object)null);
            await responseTask.ContinueWith(t =>
            {
                try
                {
                    response = (HttpWebResponse)responseTask.Result;
                }
                catch (AggregateException ae)
                {
                    foreach (Exception e in ae.InnerExceptions)
                    {
                        if (e is WebException)
                        {
                            response = (HttpWebResponse)((WebException)e).Response;
                            System.Diagnostics.Debug.WriteLine(e.Message);
                            System.Diagnostics.Debug.WriteLine(e.StackTrace);
                        }
                    }
                }
            });
            return response;
        }
    }
