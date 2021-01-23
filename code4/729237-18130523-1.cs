            public static string LlamarWebService(string url)
            {
    
                try
                {
                    System.Net.WebRequest req = System.Net.WebRequest.Create(url);
    
                    req.ContentType = "application/json";
                    req.Method = "GET";
    
                    System.Net.WebResponse resp = req.GetResponse();
                    if (resp == null) return null;
                    System.IO.StreamReader sr =
                          new System.IO.StreamReader(resp.GetResponseStream());
    
                    string respuesta = sr.ReadToEnd().Trim();
                    return respuesta;
    
                }
                catch (Exception ex)
                {
                    throw ex;
                    // return "";
                    //throw or return an appropriate response/exception
                }
            }
