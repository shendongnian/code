            public static void GetImageFromUrl(string url)
        {
            string RefererUrl = string.Empty;
            int TimeoutMs = 22 * 1000;
            string requestAccept = "*/*";
            string UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.1.7) Gecko/20091221 Firefox/3.5.7";
          //  Bitmap img = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = UserAgent;
            request.Timeout = TimeoutMs;
            request.ReadWriteTimeout = TimeoutMs * 6;
            request.Accept = requestAccept;
            if (!string.IsNullOrEmpty(RefererUrl))
            {
                request.Referer = RefererUrl;
            }
            try
            {
                WebResponse wResponse = request.GetResponse();
                using (HttpWebResponse response = wResponse as HttpWebResponse)
                {
                    Stream responseStream = response.GetResponseStream();
                    BinaryReader br = new BinaryReader(responseStream);
                    FileStream fs = new FileStream(@"c:\pst\1.jpg", FileMode.Create, FileAccess.Write);
                    const int buffsize = 1024;
                    byte[] bytes = new byte[buffsize];
                    int totalread = 0;
                    int numread = buffsize;
                    while (numread != 0)
                    {
                        // read from source
                        numread = br.Read(bytes, 0, buffsize);
                        totalread += numread;
                        // write to disk
                        fs.Write(bytes, 0, numread);
                    }
                    br.Close();
                    fs.Close();
                    response.Close();
                }
            }
            catch (Exception)
            {
            }
        } 
