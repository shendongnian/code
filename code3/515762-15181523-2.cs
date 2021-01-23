        // Returns the results of fetching the requested HTML page.
        public static void SaveHttpResponseAsFile(string RequestUrl, string FilePath)
        {
            try
            {
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(RequestUrl);
                httpRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
                httpRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
                HttpWebResponse response = null;
                try
                {
                    response = (HttpWebResponse)httpRequest.GetResponse();
                }
                catch (System.Net.WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ProtocolError)
                        response = (HttpWebResponse)ex.Response;
                }
                using (Stream responseStream = response.GetResponseStream())
                {
                    Stream FinalStream = responseStream;
                    if (response.ContentEncoding.ToLower().Contains("gzip"))
                        FinalStream = new GZipStream(FinalStream, CompressionMode.Decompress);
                    else if (response.ContentEncoding.ToLower().Contains("deflate"))
                        FinalStream = new DeflateStream(FinalStream, CompressionMode.Decompress);
                    using (var fileStream = System.IO.File.Create(FilePath))
                    {
                        FinalStream.CopyTo(fileStream);
                    }
                    response.Close();
                    FinalStream.Close();
                }
            }
            catch
            { }
        }
