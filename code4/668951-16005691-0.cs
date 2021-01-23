     static void Main(string[] args)
            {
                CopyFile("countrylist.csv", "MySample.csv", "username", "password#");
            }
    
            public static bool CopyFile(string fileName, string FileToCopy, string userName, string password)
            {
                try
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://ftp.mysite.net/" + fileName);
                    request.Method = WebRequestMethods.Ftp.DownloadFile;
    
                    request.Credentials = new NetworkCredential(userName, password);
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    Upload("ftp://ftp.mysite.net/" + FileToCopy, ToByteArray(responseStream), userName, password);
                    responseStream.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            public static Byte[] ToByteArray(Stream stream)
            {
                MemoryStream ms = new MemoryStream();
                byte[] chunk = new byte[4096];
                int bytesRead;
                while ((bytesRead = stream.Read(chunk, 0, chunk.Length)) > 0)
                {
                    ms.Write(chunk, 0, bytesRead);
                }
    
                return ms.ToArray();
            }
    
    
            public static bool Upload(string FileName, byte[] Image, string FtpUsername, string FtpPassword)
            {
                try
                {
                    System.Net.FtpWebRequest clsRequest = (System.Net.FtpWebRequest)System.Net.WebRequest.Create(FileName);
                    clsRequest.Credentials = new System.Net.NetworkCredential(FtpUsername, FtpPassword);
                    clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
                    System.IO.Stream clsStream = clsRequest.GetRequestStream();
                    clsStream.Write(Image, 0, Image.Length);
    
                    clsStream.Close();
                    clsStream.Dispose();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
