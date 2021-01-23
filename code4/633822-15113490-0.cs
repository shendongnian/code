    private static HttpResponse GetAnyResponse(this HttpRequest req)
    {
       HttpResponse retVal = null;
    
       try
       {
          retVal = (HttpWebResponse)req.GetResponse()
       }
       catch (WebException webEx)
       {
          retVal = webEx.Response;
       }
       catch (Exception ex)
       {
          // these are the "bad" exceptions, let them pass
          throw;
       }
       
       return webEx;   
    }
