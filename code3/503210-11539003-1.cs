     using (CookieAwareWebClient client = new CookieAwareWebClient(Cookies))
            {
                string data = Encoding.Default.GetString(client.DownloadData(m_uri));
                try
                {
                    NameValueCollection values = new NameValueCollection { { "type", "arg1" } };
                    string URL1 = "http://x/search.jsp";
                    client.Headers[HttpRequestHeader.KeepAlive] = "true";
                    client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    client.Headers[HttpRequestHeader.Accept] = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                    client.Headers[HttpRequestHeader.AcceptEncoding] = "gzip,deflate,sdch";
                    client.Headers[HttpRequestHeader.AcceptLanguage] = "en-US,en;q=0.8";
                    client.Headers[HttpRequestHeader.CacheControl] = "max-age=0";
                    
                    byte[] result = client.UploadValues(URL1, "POST", values);
                    string result1String = Encoding.UTF8.GetString(result);
                    Console.WriteLine();
    }
