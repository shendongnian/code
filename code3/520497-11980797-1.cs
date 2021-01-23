     WebClient webClient = new WebClient();
            string webAddress = null;
            try
            {
                webAddress = @"http://myCompany/ShareDoc/";
    
                webClient.Credentials = CredentialCache.DefaultCredentials;
    
                WebRequest serverRequest = WebRequest.Create(webAddress);
                WebResponse serverResponse;
                serverResponse = serverRequest.GetResponse();
                serverResponse.Close();
    
                webClient.UploadFile(webAddress + logFileName, "PUT", logFileName);
                webClient.Dispose();
                webClient = null;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
