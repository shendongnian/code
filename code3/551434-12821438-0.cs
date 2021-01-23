    class Program
    {
        static void Main(string[] args)
        {
            Utils.FTPClient client = new Utils.FTPClient("ftp://localhost", "ftpUser", "ftpPass");
            List<string> files = client.DirectoryListing();
            foreach (string s in files)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }
    }
    
    public List<string> DirectoryListing()
    {
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_remoteHost);
        request.Method = WebRequestMethods.Ftp.ListDirectory;
        request.Credentials = new NetworkCredential(_remoteUser, _remotePass);
        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
        Stream responseStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(responseStream);
     
        List<string> result = new List<string>();
     
        while (!reader.EndOfStream)
        {
            result.Add(reader.ReadLine());
        }
     
        reader.Close();
        response.Close();
        return result;
    }
