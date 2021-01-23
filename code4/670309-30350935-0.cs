            WebRequest request = WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Get;
            NetworkCredential networkCredential = new NetworkCredential(logon, password); // logon in format "domain\username"
            CredentialCache myCredentialCache = new CredentialCache {{new Uri(url), "Basic", networkCredential}};
            request.PreAuthenticate = true;
            request.Credentials = myCredentialCache;
            using (WebResponse response = request.GetResponse())
            {
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                using (Stream dataStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        string responseFromServer = reader.ReadToEnd();
                        Console.WriteLine(responseFromServer);
                    }
                }
            }
