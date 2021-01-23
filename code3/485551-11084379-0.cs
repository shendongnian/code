    public static string GetResponse(string endPoint)
            {
                HttpWebRequest request = CreateWebRequest(endPoint);
    
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var responseValue = string.Empty;
    
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
    
                    return responseValue;
                }
            }
