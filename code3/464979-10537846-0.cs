    private static string GetTemplate(string queryparams)
    {
        WebRequest request = HttpWebRequest.Create(uri);
        request.Method = WebRequestMethods.Http.Get;
        WebResponse response = request.GetResponse();
 
        using(StreamReader reader = new StreamReader(response.GetResponseStream())){
             
             string tmp = reader.ReadToEnd();
             response.Close();
        }
        
        // here will be called Dispose() of the reader 
        // automatically whenever there is an exception or not.
    }
