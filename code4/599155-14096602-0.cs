    static void Main()
        {
            string httpAddr = "http://192.168.56.101";
             var  client = new WebClient();
            try
            {
                client.DownloadFile(@"" + httpAddr + ":5151/readme.txt", "readme.txt");
            }
            catch
            {
                client.DownloadFile(@"" + httpAddr + ":5151/readme.txt", "readme.txt");
            }
        }
 
