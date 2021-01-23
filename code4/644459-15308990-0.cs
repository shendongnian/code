    try{
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        /* Set HTTP header values */
        request.Method = "MethodYouWantToUse"; // GET, POST etc.
        request.UserAgent = "SomeUserAgent";
        // Other header values here...
    
        HttpWebResponse response = (HttpWebResponse)request.GetResponse(); 
        TextBox2.Text = "HTTP Response is: {0}", response.StatusDescription);
    }
    catch(WebException wex){
        if(wex.Response != null){
            HttpWebResponse response = wex.Response as HttpWebResponse;
                if (response.StatusCode != HttpStatusCode.OK) {
                    TextBox2.Text = "HTTP Response is: {0}", response.StatusDescription);
                }            
        }
    }
