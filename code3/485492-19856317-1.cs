    /// <summary>
        /// Class JsonService.
        /// </summary>
        public class JsonService : BaseJsonService
        {
            /// <summary>
            /// Gets the specified URL.
            /// </summary>
            /// <typeparam name="TResponse">The type of the attribute response.</typeparam>
            /// <param name="url">The URL.</param>
            /// <param name="onComplete">The configuration complete.</param>
            /// <param name="onError">The configuration error.</param>
            public override void Get<TResponse>(string url, Action<TResponse> onComplete, Action<Exception> onError)
            {
                if (client == null)
                    client = new WebClient();
    
                client.DownloadStringCompleted += (s, e) =>
                {
                    TResponse returnValue = default(TResponse);
    
                    try
                    {
                        returnValue = JsonConvert.DeserializeObject<TResponse>(e.Result);
                        onComplete(returnValue);
                    }
                    catch (Exception ex)
                    {
                        onError(new JsonParseException(ex));
                    }
                };
    
                client.Headers.Add(HttpRequestHeader.Accept, "application/json");
                client.Encoding = System.Text.Encoding.UTF8;
    
                client.DownloadStringAsync(new Uri(url));
            }
            /// <summary>
            /// Posts the specified URL.
            /// </summary>
            /// <typeparam name="TResponse">The type of the attribute response.</typeparam>
            /// <param name="url">The URL.</param>
            /// <param name="jsonData">The json data.</param>
            /// <param name="onComplete">The configuration complete.</param>
            /// <param name="onError">The configuration error.</param>
            public override void Post<TResponse>(string url, string jsonData, Action<TResponse> onComplete, Action<Exception> onError)
            {
                if (client == null)
                    client = new WebClient();
    
                client.UploadDataCompleted += (s, e) =>
                {
                    if (e.Error == null && e.Result != null)
                    {
                        TResponse returnValue = default(TResponse);
    
                        try
                        {
                            string response = Encoding.UTF8.GetString(e.Result);
                            returnValue = JsonConvert.DeserializeObject<TResponse>(response);
                        }
                        catch (Exception ex)
                        {
                            onError(new JsonParseException(ex));
                        }
    
                        onComplete(returnValue);
                    }
                    else
                        onError(e.Error);
                };
    
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Encoding = System.Text.Encoding.UTF8;
    
                byte[] data = Encoding.UTF8.GetBytes(jsonData);
                client.UploadDataAsync(new Uri(url), "POST", data);
            }
        }
