    public class NoKeepAlivesWebClient : WebClient
    {
        public override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address) as HttpWebRequest;
            if (request != null)
            {
                request.KeepAlive = false;
            }
        }
    }
