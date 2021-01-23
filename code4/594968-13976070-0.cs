    private bool KickServices(string serviceUrl)
            {
                bool result = false;
    
                var request = WebRequest.Create(serviceUrl) as HttpWebRequest;
                if (request != null)
                {
                    request.ContentType = "application/xml";
                    request.Method = "GET";
                }
    
                if (request != null)
                {
                    var response = request.GetResponse() as HttpWebResponse;
                    if (response != null && response.StatusCode == HttpStatusCode.OK)
                    {
                        string resultContent = null;
                        Encoding responseEncoding = Encoding.GetEncoding(response.CharacterSet);
                        using (var sr = new StreamReader(response.GetResponseStream(), responseEncoding))
                        {
                            resultContent = sr.ReadToEnd();
                            if (resultContent.Contains(serviceUrl))
                                result = true;
                        }
                    }
                }
    
                return result;
            }
