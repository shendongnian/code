    public bool Upload(string title, string description, Catagory catagory,
                  string keywords, string videoFileName, out string error)
    {
        bool result = false;
        error = null;
     
        // Build byte arrays for the header file and footer
        byte[] header = Encoding.UTF8.GetBytes(GetHeader(title, description, catagory, keywords, videoFileName));
        byte[] file = File.ReadAllBytes(videoFileName);
        byte[] footer = Encoding.UTF8.GetBytes(lineTerm + boundary + "--");
     
        // Combine the byte arrays into one big byte array
        byte[] data = new byte[header.Length + file.Length + footer.Length];
        Array.Copy(header, 0, data, 0, header.Length);
        Array.Copy(file, 0, data, header.Length, file.Length);
        Array.Copy(footer, 0, data, header.Length + file.Length, footer.Length);
     
        // Using a HttpWebRequest here because it allows us to control the timeout
        HttpWebRequest req = (HttpWebRequest)WebRequest
            .Create(string.Format("http://uploads.gdata.youtube.com/feeds/api/users/{0}/uploads",
                    username));
        req.Method = "POST";
        req.ContentType = string.Format("multipart/related; boundary={0};", boundaryheader);
        req.ContentLength = data.Length;
        req.Timeout = timeout;
        req.Headers.Add("Authorization", "GoogleLogin auth=" + authCode);
        req.Headers.Add("X-GData-Client", clientCode); // supposed to be optional
        req.Headers.Add("X-GData-Key", devCode);
        req.Headers.Add("Slug", Path.GetFileName(videoFileName));
     
        using (Stream postStream = req.GetRequestStream())
        {
            // Send the data to the server
            postStream.WriteTimeout = timeout;
            postStream.Write(data, 0, data.Length);
            postStream.Close();
     
            try
            {
                // Get the response back from the server
                WebResponse webResponse = req.GetResponse();
                using (Stream responseStream = webResponse.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        // Should check the response here
                        reader.Close();
                        result = true;
                    }
     
                    responseStream.Close();
                }
     
                webResponse.Close();
            }
            catch (WebException ex)
            {
                // Got a bad response
                using (StreamReader sr = new StreamReader(ex.Response.GetResponseStream()))
                {
                    error = sr.ReadToEnd();
                }
            }
        }
     
        return result;
    }
