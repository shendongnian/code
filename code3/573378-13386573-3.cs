    void WriteFile(HttpListenerContext ctx)
    {
        var response = ctx.Response;
        using (FileStream fs = File.OpenRead(@"..."))
        {
            //response is HttpListenerContext.Response...
            response.ContentLength64 = fs.Length;
            response.SendChunked = false;
            response.ContentType = System.Net.Mime.MediaTypeNames.Application.Octet;
            response.AddHeader("Content-disposition", "attachment; filename=largefile.zip");
            byte[] buffer = new byte[64 * 1024];
            int read;
            using (BinaryWriter bw = new BinaryWriter(response.OutputStream))
            {
                while ((read = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    bw.Write(buffer, 0, read);
                    bw.Flush(); //seems to have no effect
                }
                bw.Close();
            }
            response.StatusCode = (int)HttpStatusCode.OK;
            response.StatusDescription = "OK";
            response.OutputStream.Close();
        }
    }
