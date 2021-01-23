    try
    {
        HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
        using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
        {
            post_response = responseStream.ReadToEnd();
            responseStream.Close();
        }
    }
    catch(WebException wex)
    {
        HttpWebResponse response = (HttpWebResponse)wex.Response;
        
        if(response != null)
        {
            HttpStatusCode responseCode = response.StatusCode;
            String statusDescription = response.StatusDescription;
            // Add your status code logic here
        }
    }
