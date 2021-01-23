    public class WebServiceCaller : IWebServiceCaller
    {
        private NetworkCredentials credentials { get; set; }
    
        public WebServiceCaller()
        {
            this.credentials = new NetworkCredentials("Name", "Password");
        }
        // .. Whatever else you need.
    }
