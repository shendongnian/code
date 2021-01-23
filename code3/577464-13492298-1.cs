    private void CallWebService()
    {
        //Defined outside the callback
        var someFlag = true;
    
        var client = new WebClient();
        client.DownloadStringCompleted += (s, e) =>
        {
            //Using lambdas, we can access variables defined outside the callback
            if (someFlag)
            {
                //Do stuff with the result. 
            }
        };
    
        client.DownloadStringAsync(new Uri("http://www.microsoft.com/"));
    }
