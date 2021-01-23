    for (int i = 0; i < ParsedLinks.Count; i++)
    {
            Thread.Sleep(500);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(ParsedLinks[i]);
            req.Method = "HEAD";
            req.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            int b_Result = int.TryParse(resp.Headers.Get("Content-Length"), out i_ContentLength);
            int i_Size = (int)(i_ContentLength / 1024);
            req.Abort();
            resp.Close();
    
    }
