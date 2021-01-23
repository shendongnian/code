    private void writeBytes()
    {
        var response = this.context.Response;
        bool canGzip = true;
        if (canGzip)
        {
            Response.Filter = new System.IO.Compression.GZipStream(Response.Filter, System.IO.Compression.CompressionMode.Compress);
            Response.AppendHeader("Content-Encoding", "gzip");
        }
        else
        {
            response.AppendHeader("Content-Encoding", "utf-8");
        }
    
        response.AppendHeader("Content-Length", this.responseBytes.Length.ToString());
        response.ContentType = this.isScript ? "text/javascript" : "text/css";
        response.ContentEncoding = Encoding.Unicode;
        response.OutputStream.Write(this.responseBytes, 0, this.responseBytes.Length);
        response.Flush();
        }
    }
