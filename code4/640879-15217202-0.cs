    try 
    {
      var myHttpWebRequest = (HttpWebRequest) WebRequest.Create(pathThatReturns404);
      var myHttpWebResponse = (HttpWebResponse) myHttpWebRequest.GetResponse();
    }
    catch(WebException e) 
    {
        if(e.Status == WebExceptionStatus.ProtocolError) 
        {
            Console.WriteLine("Status Code : {0}",
                ((HttpWebResponse)e.Response).StatusCode);
        }
    }
