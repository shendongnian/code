     public HttpResponseMessage Get()
            {
                
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://www.google.ca");
    
                    return httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ContinueWith((t) =>
                            {
                                return new HttpResponseMessage()
                                    {
                                        Content = t.Result.Content
                                    };
                            }).Result;
    
                }
    
            }
