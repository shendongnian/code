    var req = (HttpWebRequest)HttpWebRequest.Create(url);
    using (var resp = req.GetResponse())
    {
        using (var stream = resp.GetResponseStream())
        {
            byte[] buffer = new byte[0x10000];
            int len;
            while ((len = stream.Read(buffer, 0, buffer.Length))>0)
            {
                //Do with the content whatever you want
                // ***YOUR CODE*** 
                fileStream.Write(buffer, 0, len);
            }
        }
    }
