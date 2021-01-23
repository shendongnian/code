    public class WebServiceClient : IDisposable
    {
        private static WebServiceClient viciousReference = null;
        
        public WebServiceClient()
        {
            viciousReference = this;
        }
        ~WebServiceClient()
        {
            Dispose();
        }
        public void Dispose() 
        {  
            // Standard Dispose implementation 
        }
    }
