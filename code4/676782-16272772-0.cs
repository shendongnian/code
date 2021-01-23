    public System.Drawing.Image DownloadImageFromUrl(string imageUrl)
    {
        System.Drawing.Image image = null;
        try
        {
            System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(imageUrl);
            webRequest.AllowWriteStreamBuffering = true;
            webRequest.Timeout = 30000;
            System.Net.WebResponse webResponse = webRequest.GetResponse();
            System.IO.Stream stream = webResponse.GetResponseStream();
            image = System.Drawing.Image.FromStream(stream);
            webResponse.Close();
        }
        catch (Exception ex)
        {
            return null;
        }
        return image;
    }
