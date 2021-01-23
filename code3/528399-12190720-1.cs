       string text;
        using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
        {
            using (Stream responseStream = response.GetResponseStream())
            {
                // No need to dispose of the StreamReader as we're already
                // disposing of the stream. It wouldn't do any harm though.
                // Is the text definitely encoded in UTF-8 though?
                text = new StreamReader(responseStream).ReadToEnd();
            }
        }
