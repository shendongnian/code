     public string GetMessageViaGet(string endPoint)
            {
                HttpWebRequest request = CreateWebRequest(endPoint);
    
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var responseValue = string.Empty;
    
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        string message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                        throw new ApplicationException(message);
                    }
    
                    // grab the response  
                    using (var responseStream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                    }
    
                    return responseValue;
                }
            }
            private HttpWebRequest CreateWebRequest(string endPoint)
            {
                var request = (HttpWebRequest)WebRequest.Create(endPoint);
    
                request.Method = "GET";
                request.ContentLength = 0;
                request.ContentType = "text/xml";
                return request;
            }
