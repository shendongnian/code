    public static void GETRequest()
    {
        if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            return; //or alert the user there is no connection
        
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://url");
        request.Method = "GET";
        HttpStatusCode status;
        HttpWebResponse response;
        try
        {
           response = (HttpWebResponse)request.GetResponse();
           status = response.StatusCode;
           Console.WriteLine((int)response.StatusCode);
           Console.WriteLine(status);
        }
        catch (WebException e)
        {
           status = ((HttpWebResponse)e.Response).StatusCode;
           Console.WriteLine(status);
        }
    }
