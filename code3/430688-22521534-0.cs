    private void CreateTag()
    {
        try
        {
            MIBPContractClient OMIBPClient = new MIBPContractClient();
            UserCredential oCredential = new UserCredential();
            oCredential.AccessToken = "Enter your access token";         
            URITag uriTag = new URITag();
            uriTag.Title = "My Tag Title";
            uriTag.MedFiUrl = "http://www.something.com";
            uriTag.UTCStartDate = new DateTime(yyyy, mm, dd);
            uriTag.UTCEndDate = new DateTime(yyyy, mm, dd);
            uriTag.PublicTitle = "My Tag Public Title";
            OMIBPClient.CreateTag(oCredential, "Main", uriTag);
        }
        catch
        {
            throw;
        }
    }
            
