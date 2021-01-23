       public string GetMessageViaPost(string endPoint, string paramtersJson)
            {
                string responseValue;
                byte[] bytes = Encoding.UTF8.GetBytes(paramtersJson);
    
                HttpWebRequest request = CreateWebRequest(endPoint, bytes.Length);
    
                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                }
    
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        string message = String.Format("POST failed. Received HTTP {0}", response.StatusCode);
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
                }
    
                return responseValue;
            }
    
            private HttpWebRequest CreateWebRequest(string endPoint, Int32 contentLength)
            {
                var request = (HttpWebRequest)WebRequest.Create(endPoint);
    
                request.Method = "POST";
                request.ContentLength = contentLength;
                request.ContentType = "application/json";// "application/x-www-form-urlencoded";
    
                return request;
            }
