    public void ProcessRequest(HttpContext context)
        {
            string userName = context.Request.QueryString["Name"];
    
            context.Response.ContentType = "image/jpeg";
            Stream strm = ShowEmpImage(userName);
            try
            {
                byte[] buffer = new byte[4096];
                int byteSeq = strm.Read(buffer, 0, 4096);
    
                while (byteSeq > 0)
                {
                    context.Response.OutputStream.Write(buffer, 0, byteSeq);
                    byteSeq = strm.Read(buffer, 0, 4096);
                }
            }
            catch (NullReferenceException)
            {
                context.Response.WriteFile("img/default.png");
            }
        }
