    public void ProcessRequest(HttpContext context)
     {
        const int BufferSize = 4096;    
    
        HttpRequest request = context.Request;
    
        context.Response.ContentType = "text/html";
        context.Response.ContentEncoding = System.Text.Encoding.UTF8;
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        var tempFilePath = Path.GetTempFileName();        
        
        using (Stream fs = File.OpenWrite(tempFilePath));
        {
            byte[] buffer = new byte[BufferSize];
            int read = -1;
            while(read = request.InputStream.Read(buffer, 0, buffer.Length) > 0)
            {            
                 fs.Write(buffer, 0, buffer.Length);             
            }
        }
    
        context.Response.Write("{\"success\":true}");
        context.Response.End();
     }
