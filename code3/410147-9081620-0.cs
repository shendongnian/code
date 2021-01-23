    // Assuming url is the  url to the S3 object.
    var buffer = new byte[1024*8]; // 8k buffer. 
    var request = (HttpWebRequest)WebRequest.Create(url);
    var response = request.GetResponse();
    int bytesRead = 0;
    using (var responseStream = response.GetResponseStream())
    {
        while((bytesRead = responseStream.Read(buffer, 0, buffer.Length)) != 0)
        {
             Response.OutputStream.Write(buffer, 0, bytesRead);
        }
    }
