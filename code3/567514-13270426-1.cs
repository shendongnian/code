    public void CheckWebFoldersExist()
     {
      try
       {
        WebClient client = new WebClient();
        client.Credentials = CredentialCache.DefaultCredentials;
        // Create a request for the URL.         
        WebRequest request = WebRequest.Create("myAddress");
        // If required by the server, set the credentials.
        request.Credentials = CredentialCache.DefaultCredentials;
        // Get the response.
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //check response status
        if (string.Compare(response.StatusDescription, "OK", true) == 0)
        { 
           //URL exists so that means folder exists
        }
        else
        {
            //URL does not exist so that means folder does not exist
        }
      }
       catch (Exception error)
       {
          //error catching
       }
    }
