    Uri url = new Uri("http://www.google.nl");
    WebRequest request = (HttpWebRequest)WebRequest.Create("http://" + url.Host + "/favicon.ico");
    
    Bitmap bm = new Bitmap(32,32); 
    MemoryStream memStream;
    using (Stream response = request.GetResponse().GetResponseStream())
    {
        memStream = new MemoryStream();
        byte[] buffer = new byte[1024];
        int byteCount;
            
        do
        {
            byteCount = response.Read(buffer, 0, buffer.Length);
            memStream.Write(buffer, 0, byteCount);
        } while (byteCount > 0);
    }
    bm = new Bitmap(Image.FromStream(memStream));                 
    
    if (bm != null) 
    {
        Icon ic = Icon.FromHandle(bm.GetHicon());
        this.Icon = ic;
    }
