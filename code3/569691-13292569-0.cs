    public virtual bool WebResourceExists(string url)
    {
        WebHeaderCollection headers = null;
        WebResponse response = null;
        try
        {
            if (url.StartsWith(@"//") {
               url = "http:";
            }
            WebRequest request = WebRequest.Create(url);
            request.Method = "HEAD";
            response = request.GetResponse();
            headers = response.Headers;
            bool result = int.Parse(headers["Content-Length"]) > 0;
            return result;
        }
        catch (System.Net.WebException)
        {
            if (url.StartsWith(@"http://") {
               url = url.Replace("http://","https://");
            } else {
               return false;
            }
            try {
                WebRequest request = WebRequest.Create(url);
                request.Method = "HEAD";
                response = request.GetResponse();
               headers = response.Headers;
               bool result = int.Parse(headers["Content-Length"]) > 0;
               return result;
           }
           catch (System.Net.WebException)
           {
                return false;
           }
        }
        catch (Exception e)
        {
            _log.Error(e);
            return false;
        }
        finally
        {
            if (response != null)
            {
                response.Close();
            }
        }
    }
