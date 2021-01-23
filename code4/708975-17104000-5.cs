    private void Download()
    {
        //Create de request
        HttpWebRequest webRequest = WebRequest.Create("https://test.website.fr/website/api/test/") as HttpWebRequest;
    
        webRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.0.1) Gecko/2008070208 Firefox/3.0.1";
        webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
    
        //encode to Base64
        string sAuthorization = "username:password";
        byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sAuthorization);
        string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
    
        //Add authentification to request's header
        webRequest.Headers.Add("Authorization: Basic " + returnValue);
    
        try
        {
            //Get response
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            Stream input = webResponse.GetResponseStream(); //Store the response in a Stream
    
            //Transform stream to byte array
            byte[] tabTempTest = ReadFully(input);
            int i = tabTempTest.Length;
    
            WitreToDatabase(tabTempTest, i);
    
    
    
            //At this moment, your file is write in database !!!
            //Then i'll go to get this file from database
    
            //my param idFile indicate the file in the db
            int idFile = 6;
            byte[] fileFromDatabase = GetFileFromDB(idFile);
    
            //Here, your file is store in the byte array.
            //Now, just write this in a file
    
            //Convert to a Stream
            Stream newStream = new MemoryStream(fileFromDatabase);
    
            //Create the file
            using (Stream file = File.OpenWrite("NewFile.pdf"))
            {
                CopyStreamToFile(newStream, file);
            }
    
            //Clore the procedure
            webRequest.GetResponse().Close();
        }
        catch (WebException ex)
        {
            int iRetourcode = 0;
            if (ex.Status == WebExceptionStatus.ProtocolError)
            {
                var response = ex.Response as HttpWebResponse;
                if (response != null)
                {
                    iRetourcode = (int)response.StatusCode;
                }
                else
                {
                    // no http status code available
                }
            }
            else
            {
                // no http status code available
            }
        }
    }
