        private string UseHttpWebApproach<T>(string serviceUrl, string resourceUrl, string method, T requestBody)
        {
                string responseMessage = null;                
                var request = WebRequest.Create(string.Concat(serviceUrl, resourceUrl)) as HttpWebRequest;
                if (request != null)
                {
                    request.ContentType = "application/json";
                    request.Method = method;
                }
                if(method == "POST" && requestBody != null)
                {                   
                    byte[] requestBodyBytes = ToByteArrayUsingJsonContractSer(requestBody);                
                    request.ContentLength = requestBodyBytes.Length;
                    using (Stream postStream = request.GetRequestStream())
                        postStream.Write(requestBodyBytes, 0, requestBodyBytes.Length);
                }
    
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
                return responseMessage;
        }
        private static byte[] ToByteArrayUsingJsonContractSer<T> (T requestBody)
        {
            byte[] bytes = null;
            var serializer1 = new DataContractJsonSerializer(typeof(T));
            var ms1 = new MemoryStream();
            serializer1.WriteObject(ms1, requestBody);
            ms1.Position = 0;
            var reader = new StreamReader(ms1);
            bytes = ms1.ToArray();
            return bytes;
        }
