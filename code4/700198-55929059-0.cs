    public static void RespondFile(this HttpListenerContext context, string path, bool download = false) {
    
        HttpListenerResponse response = context.Response;
    
        // tell the browser to specify the range in bytes
        response.AddHeader("Accept-Ranges", "bytes");
    
        response.ContentType = GetMimeType(path);
        response.SendChunked = false;
    
        // open stream to file we're sending to client
        using(FileStream fs = File.OpenRead(path)) {
    
            // format: bytes=[start]-[end]
            // documentation: https://tools.ietf.org/html/rfc7233#section-4
            string range = context.Request.Headers["Range"];
            long bytes_start = 0,
            bytes_end = fs.Length;
            if (range != null) {
                string[] range_info = context.Request.Headers["Range"].Split(new char[] { '=', '-' });
                bytes_start = Convert.ToInt64(range_info[1]);
                if (!string.IsNullOrEmpty(range_info[2])) 
    				bytes_end = Convert.ToInt64(range_info[2]);
                response.StatusCode = 206;
                response.AddHeader("Content-Range", string.Format("bytes {0}-{1}/{2}", bytes_start, bytes_end - 1, fs.Length));
            }
    
            // determine how many bytes we'll be sending to the client in total
            response.ContentLength64 = bytes_end - bytes_start;
    
            // go to the starting point of the response
            fs.Seek(bytes_start, SeekOrigin.Begin);
    
            // setting this header tells the browser to download the file
            if (download) 
    			response.AddHeader("content-disposition", "attachment; filename=" + Path.GetFileName(path));
    
            // stream video to client
            // note: closed connection during transfer throws exception
            byte[] buffer = new byte[HttpServer.BUFFER_SIZE];
            int bytes_read = 0;
            try {
    
                while (fs.Position < bytes_end) {
                    bytes_read = fs.Read(buffer, 0, buffer.Length);
                    response.OutputStream.Write(buffer, 0, bytes_read);
                }
    
                response.OutputStream.Close();
    
            } catch(Exception) {}
    
        }
    
    }
