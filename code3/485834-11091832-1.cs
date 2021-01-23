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
        // This is the line that gets you the response object
        HttpWebResponse response = (HttpWebResponse)wex.Response;
        
        if(response != null)
        {
            // You can now read the response StatusCode and StatusDescription
            HttpStatusCode responseCode = response.StatusCode;
            String statusDescription = response.StatusDescription;
            // Add your status checking logic here
        }
    }
