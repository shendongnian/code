    var request = WebRequest.Create(string.Concat(serviceUrl, resourceUrl)) as HttpWebRequest;
                if (request != null)
                {
                    request.ContentType = "application/xml";
                    request.Method = "POST";
                }    
                                   
                    byte[] requestBodyBytes = Encoding.ASCII.GetBytes(XML);
                    request.ContentLength = requestBodyBytes.Length;
                    using (Stream postStream = request.GetRequestStream())
                        postStream.Write(requestBodyBytes, 0, requestBodyBytes.Length);
                
    
                if (request != null)
                {
                    var response = request.GetResponse() as HttpWebResponse;
                    if(response.StatusCode == HttpStatusCode.OK)
                    {
                        Stream responseStream = response.GetResponseStream();
                        if (responseStream != null)
                        {
                            var reader = new StreamReader(responseStream);
    
                            responseMessage = reader.ReadToEnd();
                        }
                    }
                    else
                    {
                        responseMessage = response.StatusDescription;
                    }
                }
