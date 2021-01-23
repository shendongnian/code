    public class TimedWebClient: WebClient
    {
        // Timeout in milliseconds, default = 600,000 msec
        public int Timeout { get; set; }
        public TimedWebClient()
        {
            this.Timeout = 600000; 
        }
        protected override WebRequest GetWebRequest(Uri address)
        {
            var objWebRequest= base.GetWebRequest(address);
            objWebRequest.Timeout = this.Timeout;
            return objWebRequest;
        }
    }
    // use
    string s = new TimedWebClient {Timeout = 500}.DownloadString(URL);
