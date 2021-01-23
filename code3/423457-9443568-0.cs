        static string GetFromServer(string URL, ref CookieCollection oCookie)
        {
            //first rquest
            // Create a request for the URL. 
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL);
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
            request.AllowAutoRedirect = false;
            // If required by the server, set the credentials.
            //request.Credentials = CredentialCache.DefaultCredentials;
            request.CookieContainer = new CookieContainer();
            if (oCookie != null)
            {
                foreach (Cookie cook in oCookie)
                {
                    request.CookieContainer.Add(cook);
                }
            }
            
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            foreach (Cookie cook in response.Cookies)
            {
                oCookie.Add(cook);
            }
            // Display the status.
            while (response.StatusCode == HttpStatusCode.Found)
            {
                response.Close();
                request = (HttpWebRequest)HttpWebRequest.Create(response.Headers["Location"]);
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
                request.AllowAutoRedirect = false;
                request.CookieContainer = new CookieContainer();
                if (oCookie != null)
                {
                    foreach (Cookie cook in oCookie)
                    {
                        request.CookieContainer.Add(cook);
                    }
                }
                response = (HttpWebResponse)request.GetResponse();
                foreach (Cookie cook in response.Cookies)
                {
                    oCookie.Add(cook);
                }
            }
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams and the response.
            reader.Close();
            response.Close();
            return responseFromServer;
        }
