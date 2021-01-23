    public class MyWebClient
    {
        private WebClient HiddenWebClient {get; set;}
    
        // proxy sample
        public void DownloadFile (string address, string fileName)
        {
            HiddenWebClient.DownloadFile(address, fileName);
        }
    
       // other proxy methods & your specific implementation come here.
    
    }
