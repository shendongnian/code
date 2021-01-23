    public Image GetImage(int width, int height)
    {
        string uri = string.Format("http://localhost:8000/Service/picture/{0}/{1}", width, height);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            using (Stream stream = response.GetResponseStream())
            {
                return new Bitmap(stream);
            }
        }
    }
