    private void button1_Click(object sender, EventArgs e) {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri("http://dl.opensubtitles.org/en/download/sub/4860863"));
        //request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.116 Safari/537.36";
        //request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*//*;q=0.8";
        //request.Headers["Accept-Encoding"] = "gzip,deflate,sdch";
        request.Headers["Cookie"] = "PHPSESSID=gk86hdrce96pu06kuajtue45a6; ts=1372177758";
        using (WebResponse response = request.GetResponse())
        using (Stream stream = response.GetResponseStream()) {
            string contentType = response.ContentType;
            // TODO: examine the content type and decide how to name your file
            string filename = "test.zip";
            // Download the file
            using (Stream file = File.OpenWrite(filename)) {
                byte[] buffer = ReadFully(stream, 256);
                stream.Read(buffer, 0, buffer.Length);
                file.Write(buffer, 0, buffer.Length);
            }
        }
    }
    /// <summary>
    /// Reads data from a stream until the end is reached. The
    /// data is returned as a byte array. An IOException is
    /// thrown if any of the underlying IO calls fail.
    /// </summary>
    /// <param name="stream">The stream to read data from</param>
    /// <param name="initialLength">The initial buffer length</param>
    public static byte[] ReadFully(Stream stream, int initialLength) {
        // If we've been passed an unhelpful initial length, just
        // use 32K.
        if (initialLength < 1) {
            initialLength = 32768;
        }
        byte[] buffer = new byte[initialLength];
        int read = 0;
        int chunk;
        while ((chunk = stream.Read(buffer, read, buffer.Length - read)) > 0) {
            read += chunk;
            // If we've reached the end of our buffer, check to see if there's
            // any more information
            if (read == buffer.Length) {
                int nextByte = stream.ReadByte();
                // End of stream? If so, we're done
                if (nextByte == -1) {
                    return buffer;
                }
                // Nope. Resize the buffer, put in the byte we've just
                // read, and continue
                byte[] newBuffer = new byte[buffer.Length * 2];
                Array.Copy(buffer, newBuffer, buffer.Length);
                newBuffer[read] = (byte)nextByte;
                buffer = newBuffer;
                read++;
            }
        }
        // Buffer is now too big. Shrink it.
        byte[] ret = new byte[read];
        Array.Copy(buffer, ret, read);
        return ret;
    }
