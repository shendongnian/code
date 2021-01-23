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
                    byte[] buffer;
                    for (int i = 0; i < fs.Length; i += bytesPerChunk) {
                        buffer = br.ReadBytes(bytesPerChunk);
                        bw.Write(buffer);
                        bytesRead += Convert.ToUInt32(bytesPerChunk);
                        updateProgress(bytesRead);
                    }
                }
            }
        }
    }
