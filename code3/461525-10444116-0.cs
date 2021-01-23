    byte[] content;       
    HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(url);    
    WebResponse response1 = request1.GetResponse();
    Stream stream = response1.GetResponseStream();
    using (BinaryReader br = new BinaryReader(stream))
    {
        content = br.ReadBytes((int)stream.Length);
        br.Close();
    }
    response1.Close();
    
    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://ftp_path");
    request.Method = WebRequestMethods.Ftp.UploadFile;
    
    request.Credentials = new NetworkCredential("abc", "123");
    request.ContentLength = content.Length;
    Stream requestStream = request.GetRequestStream();
    requestStream.Write(content, 0, content.Length);
    requestStream.Close();
    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
    response.Close();
