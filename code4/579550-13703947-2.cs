     public async Task<RequestResult> RunRequestAsync(string requestUrl, string requestMethod, object body = null)
        {
            HttpWebRequest req = WebRequest.Create(requestUrl) as HttpWebRequest;
            req.ContentType = "application/json";
            req.Credentials = new System.Net.NetworkCredential(User, Password);
            string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", User, Password)));
            var authHeader = string.Format("Basic {0}", auth);
            req.Headers["Authorization"] = authHeader;
            req.Method = requestMethod; //GET POST PUT DELETE
            req.Accept = "application/json, application/xml, text/json, text/x-json, text/javascript, text/xml";
            if (body != null)
            {
                var json = JsonConvert.SerializeObject(body, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                byte[] formData = UTF8Encoding.UTF8.GetBytes(json);
                var requestStream = Task.Factory.FromAsync(
                    req.BeginGetRequestStream,
                    asyncResult => req.EndGetRequestStream(asyncResult),
                    (object)null);
                var dataStream = await requestStream.ContinueWith(t => t.Result.WriteAsync(formData, 0, formData.Length));
                Task.WaitAll(dataStream);
            }
            
            Task<WebResponse> task = Task.Factory.FromAsync(
            req.BeginGetResponse,
            asyncResult => req.EndGetResponse(asyncResult),
            (object)null);
            return await task.ContinueWith(t =>
            {
                var httpWebResponse = t.Result as HttpWebResponse;
                return new RequestResult
                {
                    Content = ReadStreamFromResponse(httpWebResponse),
                    HttpStatusCode = httpWebResponse.StatusCode
                };
            });
        }
        private static string ReadStreamFromResponse(WebResponse response)
        {
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader sr = new StreamReader(responseStream))
            {
                //Need to return this response 
                string strContent = sr.ReadToEnd();
                return strContent;
            }
        }
