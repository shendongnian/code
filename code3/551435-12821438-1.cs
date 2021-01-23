    class Program
    {
        static void Main(string[] args)
        {
            FTPClient client = new FTPClient("ftp://localhost", "ftpUser", "ftpPass");
            List<string> files = client.DirectoryListing();
            foreach (string s in files)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }
    }
    
    public class FTPClient
    {
      // The hostname or IP address of the FTP server
      private string _remoteHost;
 
      // The remote username
      private string _remoteUser;
 
      // Password for the remote user
      private string _remotePass;
    
      public FTPClient(string remoteHost, string remoteUser, string remotePassword)
      {
        _remoteHost = remoteHost;
        _remoteUser = remoteUser;
        _remotePass = remotePassword;
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
  }
