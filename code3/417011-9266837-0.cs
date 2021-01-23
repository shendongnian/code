    WebRequest req = WebRequest.Create("[URL here]");
    WebResponse response = req.GetResponse();
    Stream stream = response.GetResponseStream();
    byte[] b;
    using (BinaryReader br = new BinaryReader(stream))
    {
        b = br.ReadBytes(size);
        br.Close();
    }
    
    return b;
