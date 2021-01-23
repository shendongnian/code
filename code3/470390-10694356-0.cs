    private void TestService()
    {
        try
        {
            string address = "<WCF REST service address>";
            WebClient client = new WebClient();
            string userName = "<user>";
            string password = "<password>";
            ICredentials creds = new NetworkCredential(userName, password);
            client.Credentials = creds;
            client.Headers[HttpRequestHeader.Authorization] = String.Format("Basic {0}:{1}", userName, password);
            client.Headers[HttpRequestHeader.UserAgent] = @"Mozilla/4.0 (compatible; MSIE 5.5; Windows NT 4.0)";
            Stream data = client.OpenRead(address);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            Console.WriteLine(s);
        }
        catch (WebException ex)
        {
            Console.WriteLine(ex.Message);
            if (ex.Response != null)
            {
                Stream strm = ex.Response.GetResponseStream();
                byte[] bytes = new byte[strm.Length];
                strm.Read(bytes, 0, (int)strm.Length);
                string sResponse = System.Text.Encoding.ASCII.GetString(bytes);
                Console.WriteLine(sResponse);
            }
        }
    }
