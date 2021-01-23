    static void chunkCopyFile(string source, string destination, int bytesPerChunk)
    {
        uint bytesRead = 0;
        //Instead of this:
        //using (FileStream fs = new FileStream(source, FileMode.Open, FileAccess.Read)) {
        
        //...some necessary stuff...
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.contoso.com/test.htm");
        request.Method = WebRequestMethods.Ftp.DownloadFile;
        request.Credentials = new NetworkCredential ("anonymous","janeDoe@contoso.com");
        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
          
        //Use this:
        using(Stream fs = response.GetResponseStream()){
            using (BinaryReader br = new BinaryReader(fs)) {
                using (FileStream fsDest = new FileStream(destination, FileMode.Create)) {
                    BinaryWriter bw = new BinaryWriter(fsDest);
                    long cl = response.ContentLength;
                    int bufferSize = 2048;
                    int readCount;
                    byte[] buffer = new byte[bufferSize];
                    readCount = fs.Read(buffer, 0, bufferSize);
                    while (readCount > 0)
                    {
                       bw.Write(buffer, 0, readCount);
                       readCount = fs.Read(buffer, 0, bufferSize);
                       updateProgress(readCount);
                    }
                }
            }
        }
    }
