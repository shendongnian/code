    for (int i=1; i < 1000; i++)
    {
        string id = i.ToString();
        try
        {
             string url_source = get_url_source("http://mysite.com/"+id);
        }
        catch(WebException ex)
        {
            HttpWebResponse webResponse = (HttpWebResponse)ex.Response;          
            if (webResponse.StatusCode == HttpStatusCode.NotFound)
            {
                continue;
            }
            else
            {
                throw;
            }
        }
        
    }
